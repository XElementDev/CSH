using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using XElement.CloudSyncHelper.UI.BannerCrawler;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Banners;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class BannerCrawlerModel : CrawlerModelBase</*BannerCrawler.*/ICrawlInformation, 
                                                       /*BannerCrawler.*/ICrawlResult>, 
                                      IPartImportsSatisfiedNotification
    {
        protected override ICrawlResult CrawlSingle( ICrawlInformation crawlInfo )
        {
            return this._bannerCrawler.CrawlSingle( crawlInfo );
        }

        protected override IEnumerable<ICrawlInformation> GetFilteredObjectsToCrawl( IEnumerable<string> fileNamesWoExtension )
        {
            var filteredObjectsToCrawl = this.ObjectsToCrawl.Where( otc =>
            {
                var id = otc.Id.ToString().ToLower();
                var doesAnyIdMatch = fileNamesWoExtension.Any( fn => fn.ToLower() == id );
                return !doesAnyIdMatch;
            } ).ToList();
            return filteredObjectsToCrawl;
        }

        protected override string GetIdStringFromCrawlInfo( ICrawlInformation crawlInformation )
        {
            var correspondingObjectToCrawl = this.ObjectsToCrawl.Single( 
                otc => ICrawlInformation.ReferenceEquals( crawlInformation, otc ) );
            return correspondingObjectToCrawl.Id.ToString();
        }

        protected override string ImageFileExtension { get { return IMAGE_FILE_EXTENSION; } }

        private IEnumerable<IObjectToCrawl> ObjectsToCrawl
        {
            get
            {
                return this._programInfosModel.ProgramInfoVMs.OfType<IObjectToCrawl>().ToList();
            }
        }

        protected override string PathToImageCache
        {
            get { return this._config.PathToBannerCache; }
        }

        protected override void StoreCrawlResult( ICrawlResult crawlResult )
        {
            if ( crawlResult.Image != null )
            {
                var noExtensionFileName = this.GetIdStringFromCrawlInfo( crawlResult.Input );
                var noExtensionFilePath = Path.Combine( this._config.PathToBannerCache, noExtensionFileName );
                var filePath = Path.ChangeExtension( noExtensionFilePath, IMAGE_FILE_EXTENSION );
                using ( Stream fileStream = new FileStream( filePath, FileMode.Create, FileAccess.Write ) )
                {
                    crawlResult.Image.Save( fileStream, crawlResult.Image.RawFormat );
                }
                crawlResult.Image.Dispose();
            }
        }

        [Import( typeof( IPriotizableBannerCrawler ) )]
        private IBannerCrawler _bannerCrawler = null;

        [Import]
        private IConfig _config = null;

        [Import]
        private ProgramInfosModel _programInfosModel = null;

        private const string IMAGE_FILE_EXTENSION = ".jpg";
    }
#endregion
}
