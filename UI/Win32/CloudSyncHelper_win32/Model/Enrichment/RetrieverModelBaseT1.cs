using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Timers;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Model.Enrichment
{
#region not unit-tested
    public abstract class RetrieverModelBase<TId> : NotifyPropertyChanged, 
                                                    IPartImportsSatisfiedNotification
        where TId : IRetrievalIdContainer
    {
        private void DoRetrieval()
        {
            var cachedImageFilePaths = Directory.EnumerateFiles( this.PathToImageCache,
                                                                 "*.*", SearchOption.TopDirectoryOnly );
            this._cachedImageFilePaths = cachedImageFilePaths;
        }

        protected abstract string PathToImageCache { get; }

        public string GetPathToImage( TId imageIdContainer )
        {
            var pathToIcon = default( string );

            if ( this._cachedImageFilePaths != null )
            {
                var id = imageIdContainer.Id.ToString();
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

        private IEnumerable<string> _cachedImageFilePaths;
        private BackgroundWorker _retrievalBackgroundWorker;
        private Timer _startRetrievingTimer;
    }
#endregion
}
