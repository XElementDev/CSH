using System;
using XElement.CloudSyncHelper.UI.IconCrawler;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Banners;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;
using UiIconCrawler = XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Icons;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    public class Model : NotifyPropertyChanged, 
                         /*BannerCrawler.*/IBannerId, 
                         UiIconCrawler.IIconId, 
                         UiIconCrawler.IObjectToCrawl
    {
        public Model( ProgramInfoViewModel programInfoVM ) : this( programInfoVM, null ) { }
        public Model( ProgramInfoViewModel programInfoVM, 
                      InstalledProgramViewModel installedProgramVM )
        {
            Initialize( programInfoVM, installedProgramVM );
            RegisterPropertyChangedEvents();
        }

        private FullyAutomaticSync.IModelConstructorParameters CreateFullyAutoSyncModelCtorParams()
        {
            return new Model.FullAutoSyncModelCtorParams
            {
                IsInstalled = this.IsInstalled, 
                SupportsSteamCloud = this.SupportsSteamCloud
            };
        }

        private SemiautomaticSync.IModelConstructorParameters CreateSemiautoSyncModelCtorParams()
        {
            return new Model.SemiautoSyncModelCtorParams
            {
                IsInstalled = this.IsInstalled, 
                ProgramInfoVM = this._programInfoVM
            };
        }

        public string DisplayName { get { return this._programInfoVM.DisplayName; } }

        public FullyAutomaticSync.Model FullyAutoSyncModel { get; private set; }

        Guid IRetrievalIdContainer.Id /*IBannerId. / IIconId.*/
        {
            get { return ((IRetrievalIdContainer)this._programInfoVM).Id; }
        }

        private void Initialize( ProgramInfoViewModel programInfoVM, InstalledProgramViewModel installedProgramVM )
        {
            this._installedProgramVM = installedProgramVM;
            this._programInfoVM = programInfoVM;

            var fully = this.CreateFullyAutoSyncModelCtorParams();
            this.FullyAutoSyncModel = new FullyAutomaticSync.Model( fully );
            var semi = this.CreateSemiautoSyncModelCtorParams();
            this.SemiautomaticSyncModel = new SemiautomaticSync.Model( semi );
        }

        public string InstallLocation
        {
            get
            {
                return this.IsInstalled ? 
                       this._installedProgramVM.InstallLocation : 
                       default( string );
            }
        }

        string ICrawlInformation.InstallFolderPath { get { return this.InstallLocation; } }

        public bool IsInstalled { get { return this._installedProgramVM != null; } }

        public bool IsLinked
        {
            get
            {
                var linkingDoneByCloudProvider = this.IsInstalled && this.SupportsSteamCloud;
                return this.SemiautomaticSyncModel.IsLinked || linkingDoneByCloudProvider;
            }
        }

        private void RegisterPropertyChangedEvents()
        {
            this.SemiautomaticSyncModel.PropertyChanged += ( s, e ) =>
            {
                if ( e.PropertyName == nameof( this.SemiautomaticSyncModel.IsLinked ) )
                {
                    this.RaisePropertyChanged( nameof( this.IsLinked ) );
                }
            };
        }

        public SemiautomaticSync.Model SemiautomaticSyncModel { get; private set; }

        public bool SupportsSteamCloud
        {
            get { return this._programInfoVM.SupportsSteamCloud; }
        }

        private InstalledProgramViewModel _installedProgramVM;
        private ProgramInfoViewModel _programInfoVM;


        private class FullAutoSyncModelCtorParams : FullyAutomaticSync.IModelConstructorParameters
        {
            public bool IsInstalled { get; set; }
            public bool SupportsSteamCloud { get; set; }
        }

        private class SemiautoSyncModelCtorParams : SemiautomaticSync.IModelConstructorParameters
        {
            public bool IsInstalled { get; set; }
            public ProgramInfoViewModel ProgramInfoVM { get; set; }
        }
    }
#endregion
}
