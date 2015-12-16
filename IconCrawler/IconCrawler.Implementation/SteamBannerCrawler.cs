using HtmlAgilityPack;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
#region not unit-tested
    public class SteamBannerCrawler : IPriotizableIconCrawler
    {
        public ICrawlResult /*IPriotizableIconCrawler.*/CrawlSingle( ICrawlInformation crawlInfo )
        {
            Image image = null;

            try
            {
                var searchResultEntryTag = this.GetFirstSearchResultEntry( crawlInfo );
                var title = this.ExtractSearchResultTitle( searchResultEntryTag );

                if ( this.IsExpectedTitle( title ) )
                {
                    image = this.DownloadBanner( searchResultEntryTag );
                }
            }
            catch ( XPathException ) { }

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

        private HtmlNode GetFirstSearchResultEntry( ICrawlInformation crawlInfo )
        {
            var encodedName = HttpUtility.UrlEncode( crawlInfo.SoftwareName );
            var storeSearchUri = String.Format( STORE_SEARCH_URI_FORMAT, encodedName );
            HtmlDocument htmlDoc = new HtmlWeb().Load( storeSearchUri );
            var aTag = htmlDoc.DocumentNode.SelectSingleNode( ABSOLUTE_XPATH_TO_BEST_MATCHING_ENTRY );

            if ( aTag == null )
            {
                throw new XPathException(); // Should I throw this type of exception?
            }
            else
            {
                return aTag;
            }
        }

        private bool IsExpectedTitle( string searchResult )
        {
            return true;
        }

        public Reliability Reliability { get { return Reliability.High; } }

        private const string ABSOLUTE_XPATH_TO_BEST_MATCHING_ENTRY = "//*[@id='search_result_container']/div[2]/a[1]";
        private const string RELATIVE_XPATH_TO_IMG = "./div[1]/img";
        private const string RELATIVE_XPATH_TO_TITLE = "./div[2]/div[1]/span[@class='title']";
        private const string STORE_SEARCH_URI_FORMAT = @"http://store.steampowered.com/search/?snr=1_4_4__12&term={0}";
    }
#endregion
}
