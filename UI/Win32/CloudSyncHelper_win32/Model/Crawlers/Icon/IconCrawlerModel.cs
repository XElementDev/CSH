using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using XElement.CloudSyncHelper.UI.IconCrawler;
using XElement.CloudSyncHelper.UI.Win32.Model.Crawlers;
using XElement.CloudSyncHelper.UI.Win32.Model.IconCrawler;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class IconCrawlerModel : CrawlerModelBase</*IconCrawler.*/ICrawlInformation, 
                                                       /*IconCrawler.*/ICrawlResult>, 
                                      IPartImportsSatisfiedNotification
    {
        protected override ICrawlResult CrawlSingle( ICrawlInformation crawlInfo )
        {
            return this._iconCrawler.CrawlSingle( crawlInfo );
        }

        protected override string ImageFileExtension { get { return IMAGE_FILE_EXTENSION; } }

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
                otc => Object.ReferenceEquals( crawlInformation, otc ) );
            return correspondingObjectToCrawl.Id.ToString();
        }

        private IEnumerable<IObjectToCrawl> ObjectsToCrawl
        {
            get { return this._syncObjectsModel.SyncObjectModels; }
        }

        protected override void StoreCrawlResult( ICrawlResult crawlResult )
        {
            if ( crawlResult.Icon != null )
            {
                var noExtensionFileName = this.GetIdStringFromCrawlInfo( crawlResult.Input );
                var noExtensionFilePath = Path.Combine( this._config.PathToIconCache, noExtensionFileName );
                var filePath = Path.ChangeExtension( noExtensionFilePath, ImageFileExtension );
                using ( Stream fileStream = new FileStream( filePath, FileMode.Create, FileAccess.Write ) )
                {
                    var bitmap = crawlResult.Icon.ToBitmap();
                    bitmap.Save( fileStream, ImageFormat.Png );
                }
                crawlResult.Icon.Dispose();
            }
        }

        [Import]
        private ICrawler _iconCrawler = null;

        [Import]
        private Modules.SyncObjects.Model _syncObjectsModel = null;

        private const string IMAGE_FILE_EXTENSION = ".png";
    }
#endregion
}
