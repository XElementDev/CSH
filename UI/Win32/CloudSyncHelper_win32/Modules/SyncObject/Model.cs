using System;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model.BannerCrawler;
using XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    public class Model : NotifyPropertyChanged, 
                         IBannerId,
                         FullyAutomaticSync.IModelConstructorParameters, 
                         SemiautomaticSync.IModelConstructorParameters
    {
        public Model( ProgramInfoViewModel programInfoVM ) : this( programInfoVM, null ) { }
        public Model( ProgramInfoViewModel programInfoVM, 
                      InstalledProgramViewModel installedProgramVM )
        {
            Initialize( programInfoVM, installedProgramVM );
            RegisterPropertyChangedEvents();
        }

        public string DisplayName { get { return this._programInfoVM.DisplayName; } }

        public FullyAutomaticSync.Model FullyAutoSyncModel { get; private set; }

        Guid IBannerId.Id { get { return ((IBannerId)this._programInfoVM).Id; } }

        private void Initialize( ProgramInfoViewModel programInfoVM, InstalledProgramViewModel installedProgramVM )
        {
            this._installedProgramVM = installedProgramVM;
            this._programInfoVM = programInfoVM;

            var fully = (FullyAutomaticSync.IModelConstructorParameters)this;
            this.FullyAutoSyncModel = new FullyAutomaticSync.Model( fully );
            var semi = (SemiautomaticSync.IModelConstructorParameters)this;
            this.SemiautomaticSyncModel = new SemiautomaticSync.Model( semi );
        }

        public string InstallLocation { get { return this._installedProgramVM.InstallLocation; } }

        public bool /*FullyAutomaticSync.IModelConstructorParameters.*/

                   /*SemiautomaticSync.IModelConstructorParameters.*/IsInstalled
        {
            get { return this._installedProgramVM != null; }
        }

        public bool IsLinked
        {
            get
            {
                var linkingDoneByCloudProvider = this.IsInstalled && this.SupportsSteamCloud;
                return this.SemiautomaticSyncModel.IsLinked || linkingDoneByCloudProvider;
            }
        }

        ProgramInfoViewModel /*SemiautomaticSync.*/IModelConstructorParameters.ProgramInfoVM
        {
            get { return this._programInfoVM; }
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

        public bool /*FullyAutomaticSync.IModelConstructorParameters.*/SupportsSteamCloud
        {
            get { return this._programInfoVM.SupportsSteamCloud; }
        }

        private InstalledProgramViewModel _installedProgramVM;
        private ProgramInfoViewModel _programInfoVM;
    }
#endregion
}
