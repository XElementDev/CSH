using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.XPath;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
#region not unit-tested
    public class SteamBannerCrawler : IPriotizableBannerCrawler
    {
        private Image Crawl()
        {
            Image image = null;

            try
            {
                var searchResultEntryTags = this.GetAllSearchResultEntriesOnFirstPage();
                var titlesToTagMap = this.ExtractSearchResultTitles( searchResultEntryTags );
                string bestMachtingTitle = this.GetBestMatchingTitleOrDefault( titlesToTagMap );
                if ( bestMachtingTitle != null )
                {
                    var bestMatchingEntry = titlesToTagMap[bestMachtingTitle];
                    image = this.DownloadBanner( bestMatchingEntry );
                }
            }
            catch ( XPathException ) { }

            return image;
        }

        public ICrawlResult /*IPriotizableIconCrawler.*/CrawlSingle( ICrawlInformation crawlInfo )
        {
            this._crawlInfo = crawlInfo;
            var image = this.Crawl();

            return new CrawlResult { Image = image, Input = crawlInfo };
        }

        private Image DownloadBanner( HtmlNode searchResultEntryTag )
        {
            Image image = null;

            try
            {
                var lowResBannerUri = this.GetBannerUri( searchResultEntryTag );
                var highResBannerUri = lowResBannerUri.Replace( "capsule_sm_120", "header" );
                image = this.DownloadImage( highResBannerUri );
            }
            catch ( XPathException ) { }

            return image;
        }

        private Image DownloadImage( string bannerUri )
        {
            Image image = null;
            using ( var webClient = new WebClient() )
            {
                byte[] data = webClient.DownloadData( bannerUri );
                Stream imageStream = new MemoryStream( data );
                image = Image.FromStream( imageStream );
            }
            return image;
        }

        private string ExtractSearchResultTitle( HtmlNode searchResultEntryTag )
        {
            var titleNode = searchResultEntryTag.SelectSingleNode( RELATIVE_XPATH_TO_TITLE );
            var title = titleNode.InnerText;

            return title;
        }

        private IDictionary<string, HtmlNode> ExtractSearchResultTitles( IEnumerable<HtmlNode> searchResultEntryTags )
        {
            return searchResultEntryTags.ToDictionary( tag => this.ExtractSearchResultTitle( tag ) );
        }

        private IEnumerable<HtmlNode> GetAllSearchResultEntriesOnFirstPage()
        {
            var encodedName = HttpUtility.UrlEncode( this._crawlInfo.ApplicationName );
            var storeSearchUri = String.Format( STORE_SEARCH_URI_FORMAT, encodedName );
            HtmlDocument htmlDoc = new HtmlWeb().Load( storeSearchUri );
            var aTags = htmlDoc.DocumentNode.SelectNodes( ABSOLUTE_XPATH_TO_SEARCH_RESULTS );

            if ( aTags == null || aTags.All( aTag => aTag == null ) )
            {
                throw new XPathException(); // Should I throw this type of exception?
            }
            else
            {
                return aTags;
            }
        }

        private string GetBannerUri( HtmlNode searchResultEntryTag )
        {
            var imgTag = searchResultEntryTag.SelectSingleNode( RELATIVE_XPATH_TO_IMG );

            if ( imgTag == null )
            {
                throw new XPathException(); // Should I throw this type of exception?
            }
            else
            {
                return imgTag.GetAttributeValue( "src", String.Empty );
            }
        }

        private string GetBestMatchingTitleOrDefault( IDictionary<string, HtmlNode> titlesToTagMap )
        {
            try
            {
                var search = this._crawlInfo.ApplicationName;
                var titles = titlesToTagMap.Keys;
                var bestMachtingTitle = new TitleMatcher().GetBestMatchingTitle( search, titles );
                return bestMachtingTitle;
            }
            catch (Exception ex)
            {
                return default( string );
            }
        }

        public Reliability Reliability { get { return Reliability.High; } }

        private const string ABSOLUTE_XPATH_TO_SEARCH_RESULTS = "//*[@id='search_result_container']/div[2]/a";
        private const string RELATIVE_XPATH_TO_IMG = "./div[1]/img";
        private const string RELATIVE_XPATH_TO_TITLE = "./div[2]/div[1]/span[@class='title']";
        private const string STORE_SEARCH_URI_FORMAT = @"http://store.steampowered.com/search/?snr=1_4_4__12&term={0}";

        private ICrawlInformation _crawlInfo;
    }
#endregion
}
