using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Timers;
using XElement.CloudSyncHelper.UI.Win32.Model.IconCrawler;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    public class IconRetrieverModel : ViewModelBase, IPartImportsSatisfiedNotification
    {
        private void DoRetrieval()
        {
            var cachedImageFilePaths = Directory.EnumerateFiles( this._config.PathToImageCache, 
                                                                 "*.*", SearchOption.TopDirectoryOnly );
            this._cachedImageFilePaths = cachedImageFilePaths;
        }

        public string GetPathToIcon( IIconId iconInformation )
        {
            var pathToIcon = default( string );

            if ( this._cachedImageFilePaths != null )
            {
                var id = iconInformation.Id.ToString();
                pathToIcon = this._cachedImageFilePaths.FirstOrDefault( fileName =>
                {
                    var fileNameWoExtension = Path.GetFileNameWithoutExtension( fileName );
                    return fileNameWoExtension.ToLower() == id.ToLower();
                } );
            }

            return pathToIcon;
        }

        private void InitializeRetrievalBackgroundWorker()
        {
            this._retrievalBackgroundWorker = new BackgroundWorker();
            this._retrievalBackgroundWorker.DoWork += ( s, e ) => this.DoRetrieval();
            this._retrievalBackgroundWorker.RunWorkerCompleted += ( s, e ) =>
            {
                this.RaisePropertyChanged( null );
                this._startRetrievingTimer.Start();
            };
        }

        private void InitializeRetrievingTimer()
        {
            this._startRetrievingTimer = new Timer();
            var fiveSeconds = 5000D;
            this._startRetrievingTimer.Interval = fiveSeconds;
            this._startRetrievingTimer.AutoReset = true;
            this._startRetrievingTimer.Elapsed += ( s, e ) => this.StartRetrievalInBackground();
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.DoRetrieval();

            this.InitializeRetrievalBackgroundWorker();
            this.InitializeRetrievingTimer();
            this._startRetrievingTimer.Start();
        }

        private void StartRetrievalInBackground()
        {
            this._startRetrievingTimer.Stop();
            this._retrievalBackgroundWorker.RunWorkerAsync();
        }

        [Import]
        private IConfig _config = null;

        private IEnumerable<string> _cachedImageFilePaths;
        private BackgroundWorker _retrievalBackgroundWorker;
        private Timer _startRetrievingTimer;
    }
#endregion
}
