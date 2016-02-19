using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Banners;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Icons;
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
        }

        public FullyAutomaticSync.ViewModel FullyAutomaticSyncVM { get; private set; }

        public string BannerPath
        {
            get
            {
                IBannerId bannerId = this.Model;
                return this._bannerRetrieverModel.GetPathToBanner( bannerId );
            }
        }

        public string IconPath
        {
            get
            {
                IIconId iconId = this.Model;
                return this._iconRetrieverModel.GetPathToIcon( iconId );
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

        public bool IsAnIconAvailable { get { return this.IconPath != null; } }

        public /*SyncObject.*/Model Model { get; private set; }

        private void RegisterPropertyChangedEvents()
        {
            this._bannerRetrieverModel.PropertyChanged += 
                            ( s, e ) => this.RaisePropertyChanged( nameof( this.BannerPath ) );
            this._iconRetrieverModel.PropertyChanged += ( s, e ) =>
            {
                this.RaisePropertyChanged( nameof( this.IconPath ) );
                this.RaisePropertyChanged( nameof( this.IsAnIconAvailable ) );
            };
        }

        public SemiautomaticSync.ViewModel SemiautoSyncVM { get; private set; }

        private BannerRetrieverModel _bannerRetrieverModel;
        private IconRetrieverModel _iconRetrieverModel;
    }
#endregion
}
