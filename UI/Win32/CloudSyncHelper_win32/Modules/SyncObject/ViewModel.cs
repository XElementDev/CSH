using System.Drawing;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.CloudSyncHelper.UI.Win32.Model.BannerCrawler;
using FullyAutomaticSyncViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync.ViewModel;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;
using SyncObjectModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.Model;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    public class ViewModel : NotifyPropertyChanged
    {
        public ViewModel( SyncObjectModel syncObjectModel,
                          BannerRetrieverModel bannerRetrieverModel, 
                          IconRetrieverModel iconRetrieverModel )
        {
            this.Model = syncObjectModel;
            this.FullyAutomaticSyncVM = new FullyAutomaticSyncViewModel( this.Model );

            this._bannerRetrieverModel = bannerRetrieverModel;
            this._bannerRetrieverModel.PropertyChanged +=
                ( s, e ) => this.RaisePropertyChanged( nameof( this.ImagePath ) );

            this._iconRetrieverModel = iconRetrieverModel;

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

        public FullyAutomaticSyncViewModel FullyAutomaticSyncVM { get; private set; }

        public string ImagePath
        {
            get
            {
                IBannerId iconId = this.Model;
                return this._bannerRetrieverModel.GetPathToIcon( iconId );
            }
        }

        public bool IsAnIconAvailable { get { return this.ApplicationIcon != null; } }

        public SyncObjectModel Model { get; private set; }

        private void RetrieveApplicationIcon()
        {
            if ( this.Model.IsInstalled )
            {
                var installLocation = this.Model.InstallLocation;
                var icon = this._iconRetrieverModel.GetIconFromInstallLocation( installLocation );
                this.ApplicationIcon = icon;
            }
        }

        private BannerRetrieverModel _bannerRetrieverModel;
        private IconRetrieverModel _iconRetrieverModel;
    }
#endregion
}
