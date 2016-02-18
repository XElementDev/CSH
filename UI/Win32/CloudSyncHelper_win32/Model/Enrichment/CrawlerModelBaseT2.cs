using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;

namespace XElement.CloudSyncHelper.UI.Win32.Model.Enrichment
{
#region not unit-tested
    internal abstract class CrawlerModelBase<TCrawlInformation, 
                                             TCrawlResult> 
        : IPartImportsSatisfiedNotification
    {
        protected abstract TCrawlResult CrawlSingle( TCrawlInformation crawlInfo );

        protected abstract IEnumerable<TCrawlInformation> GetFilteredObjectsToCrawl( IEnumerable<string> fileNamesWoExtension );

        protected abstract string GetIdStringFromCrawlInfo( TCrawlInformation crawlInformation );

        private IEnumerable<TCrawlInformation> GetInformationToCrawl()
        {
            var searchPattern = String.Format( "*{0}", ImageFileExtension );
            var cachedIconFilePaths = Directory.EnumerateFiles( this.PathToImageCache,
                                                                searchPattern,
                                                                SearchOption.TopDirectoryOnly );
            var fileNamesWoExtension = cachedIconFilePaths
                .Select( cifn => Path.GetFileNameWithoutExtension( cifn ) )
                .ToList();

            var filteredObjectsToCrawl = this.GetFilteredObjectsToCrawl( fileNamesWoExtension );
            return filteredObjectsToCrawl;
        }

        protected abstract string ImageFileExtension { get; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            IEnumerable<TCrawlInformation> input = this.GetInformationToCrawl();
            this.StartCrawlingInBackground( input );
        }

        protected abstract string PathToImageCache { get; }

        private void StartCrawling( IEnumerable<TCrawlInformation> input )
        {
            foreach ( var crawlInfo in input )
            {
                var result = this.CrawlSingle( crawlInfo );
                this.StoreCrawlResult( result );
            }
        }

        private void StartCrawlingInBackground( IEnumerable<TCrawlInformation> input )
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += ( s, e ) => this.StartCrawling( input );
            backgroundWorker.RunWorkerCompleted += ( s, e ) => backgroundWorker.Dispose();
            backgroundWorker.RunWorkerAsync();
        }

        protected abstract void StoreCrawlResult( TCrawlResult crawlResult );
    }
#endregion
}
