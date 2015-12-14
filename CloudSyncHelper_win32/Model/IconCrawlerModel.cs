﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private string GetGuidStringFromCrawlInfo( ICrawlInformation crawlInformation )
        {
            var programInfoVMs = this._programInfosModel.ProgramInfoVMs;
            var correspondingProgramInfoVM = programInfoVMs.Single( pi => pi == crawlInformation );
            var guid = correspondingProgramInfoVM.Id;
            return guid.ToString();
        }

        private IEnumerable<ICrawlInformation> GetInformationToCrawl()
        {
            var searchPattern = String.Format( "*{0}", IMAGE_FILE_EXTENSION );
            var cachedImageFileNames = Directory.EnumerateFiles( this._config.PathToImageCache, searchPattern );
            var fileNames = cachedImageFileNames.Select( cifn => Path.ChangeExtension( cifn, string.Empty ) ).ToList();

            var programInfoVMs = this._programInfosModel.ProgramInfoVMs;
            var filteredProgramInfoVMs = programInfoVMs.Where( pi =>
            {
                return !fileNames.Any( fn => fn.ToLower() == pi.Id.ToString().ToLower() );
            } ).ToList();
            return filteredProgramInfoVMs.OfType<ICrawlInformation>().ToList();
        }

        public void OnImportsSatisfied()
        {
            IEnumerable<ICrawlInformation> input = this.GetInformationToCrawl();
            this.StartCrawlingInBackground( input );
        }

        private void StartCrawling( IEnumerable<ICrawlInformation> input )
        {
            foreach ( var crawlInfo in input )
            {
                var result = this._iconCrawler.CrawlSingle( crawlInfo );
                this.StoreCrawlResult( result );
            }
        }

        private void StartCrawlingInBackground( IEnumerable<ICrawlInformation> input )
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += ( s, e ) => this.StartCrawling( input );
            backgroundWorker.RunWorkerCompleted += ( s, e ) => backgroundWorker.Dispose();
            backgroundWorker.RunWorkerAsync();
        }

        private void StoreCrawlResult( ICrawlResult crawlResult )
        {
            if ( crawlResult.Image != null )
            {
                var noExtensionFileName = this.GetGuidStringFromCrawlInfo( crawlResult.Input );
                var noExtensionFilePath = Path.Combine( this._config.PathToImageCache, noExtensionFileName );
                var filePath = Path.ChangeExtension( noExtensionFilePath, IMAGE_FILE_EXTENSION );
                using ( Stream fileStream = new FileStream( filePath, FileMode.Create, FileAccess.Write ) )
                {
                    crawlResult.Image.Save( fileStream, crawlResult.Image.RawFormat );
                }
                crawlResult.Image.Dispose();
            }
        }

        private const string IMAGE_FILE_EXTENSION = ".jpg";

        [Import]
        private IConfig _config = null;

        [Import( typeof( IPriotizableIconCrawler ) )]
        private IIconCrawler _iconCrawler = null;

        [Import]
        private ProgramInfosModel _programInfosModel = null;
    }
#endregion
}