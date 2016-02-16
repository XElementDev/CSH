using System.Drawing;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.CloudSyncHelper.UI.Win32.Model.BannerCrawler;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    public class ViewModel : NotifyPropertyChanged
    {
        public ViewModel( /*SyncObject.*/Model syncObjectModel,
                          BannerRetrieverModel bannerRetrieverModel, 
                          IconRetrieverModel iconRetrieverModel )
        {
            this.Initialize( syncObjectModel, bannerRetrieverModel, iconRetrieverModel );
            this.RegisterPropertyChangedEvents();
            this.RetrieveApplicationIcon();
        }

        private Icon _applicationIcon;
        public Icon ApplicationIcon
        {
            get { return this._applicationIcon; }
            private set
            {
                this._applicationIcon = value;
                this.RaisePropertyChanged( nameof( this.ApplicationIcon ) );
                this.RaisePropertyChanged( nameof( this.IsAnIconAvailable ) );
            }
        }

        public FullyAutomaticSync.ViewModel FullyAutomaticSyncVM { get; private set; }

        public string ImagePath
        {
            get
            {
                IBannerId iconId = this.Model;
                return this._bannerRetrieverModel.GetPathToIcon( iconId );
            }
        }

        private void Initialize( /*SyncObject.*/Model syncObjectModel, 
                                 BannerRetrieverModel bannerRetrieverModel, 
                                 IconRetrieverModel iconRetrieverModel )
        {
            this.Model = syncObjectModel;
            this.FullyAutomaticSyncVM = new FullyAutomaticSync.ViewModel( this.Model.FullyAutoSyncModel );
            this.SemiautoSyncVM = new SemiautomaticSync.ViewModel( this.Model.SemiautomaticSyncModel );

            this._bannerRetrieverModel = bannerRetrieverModel;
            this._iconRetrieverModel = iconRetrieverModel;
        }

        public bool IsAnIconAvailable { get { return this.ApplicationIcon != null; } }

        public /*SyncObject.*/Model Model { get; private set; }

        private void RegisterPropertyChangedEvents()
        {
            this._bannerRetrieverModel.PropertyChanged +=
                            ( s, e ) => this.RaisePropertyChanged( nameof( this.ImagePath ) );
        }

        private void RetrieveApplicationIcon()
        {
            if ( this.Model.IsInstalled )
            {
                var installLocation = this.Model.InstallLocation;
                var icon = this._iconRetrieverModel.GetIconFromInstallLocation( installLocation );
                this.ApplicationIcon = icon;
            }
        }

        public SemiautomaticSync.ViewModel SemiautoSyncVM { get; private set; }

        private BannerRetrieverModel _bannerRetrieverModel;
        private IconRetrieverModel _iconRetrieverModel;
    }
#endregion
}
