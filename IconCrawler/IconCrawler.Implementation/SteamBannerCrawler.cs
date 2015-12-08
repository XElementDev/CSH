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
            var bannerUri = this.GetBannerUri( crawlInfo );

            Image image = null;
            if ( bannerUri != null )
            {
                image = this.DownloadImage( bannerUri );
            }

            return new CrawlResult { Image = image, Input = crawlInfo };
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

        private string GetBannerUri( ICrawlInformation crawlInfo )
        {
            var encodedName = HttpUtility.UrlEncode( crawlInfo.SoftwareName );
            var storeSearchUri = String.Format( STORE_SEARCH_URI_FORMAT, encodedName );
            HtmlDocument htmlDoc = new HtmlWeb().Load( storeSearchUri );
            var imgTag = htmlDoc.DocumentNode.SelectSingleNode( XPATH_TO_BEST_MATCHING_IMG );

            if ( imgTag == null )
            {
                return null;
            }
            else
            {
                return imgTag.GetAttributeValue( "src", String.Empty );
            }
        }

        public Reliability Reliability { get { return Reliability.High; } }

        private const string STORE_SEARCH_URI_FORMAT = @"http://store.steampowered.com/search/?snr=1_4_4__12&term={0}";
        private const string XPATH_TO_BEST_MATCHING_IMG = "//*[@id='search_result_container']/div[2]/a[1]/div[1]/img";
    }
#endregion
}
