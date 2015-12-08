using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using XElement.CloudSyncHelper.UI.IconCrawler;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class IconCrawlerModel : IPartImportsSatisfiedNotification
    {
        private IEnumerable<ICrawlInformation> GetInformationToCrawl()
        {
            var programInfoVMs = this._programInfosModel.ProgramInfoVMs;
            // TODO: Throw out programInfoVMs that have already been crawled
            return programInfoVMs.OfType<ICrawlInformation>().ToList();
        }

        public void OnImportsSatisfied()
        {
            IEnumerable<ICrawlInformation> input = this.GetInformationToCrawl();
            var results = this._iconCrawler.Crawl( input );
            this.StoreCrawlResults( results );
        }

        private void StoreCrawlResult( ICrawlResult crawlResult )
        {
            if ( crawlResult.Image != null )
            {
                var fileName = Guid.NewGuid().ToString();
                var noExtensionFilePath = Path.Combine( this._config.PathToImageCache, fileName );
                var filePath = Path.ChangeExtension( noExtensionFilePath, ".jpg" );
                using ( Stream fileStream = new FileStream( filePath, FileMode.Create, FileAccess.Write ) )
                {
                    crawlResult.Image.Save( fileStream, crawlResult.Image.RawFormat );
                }
                crawlResult.Image.Dispose();
            }
        }

        private void StoreCrawlResults( IEnumerable<ICrawlResult> crawlResults )
        {
            foreach ( var crawlResult in crawlResults )
            {
                this.StoreCrawlResult( crawlResult );
            }
        }

        [Import]
        private IConfig _config = null;

        [Import( typeof( IPriotizableIconCrawler ) )]
        private IIconCrawler _iconCrawler = null;

        [Import]
        private ProgramInfosModel _programInfosModel = null;
    }
#endregion
}
