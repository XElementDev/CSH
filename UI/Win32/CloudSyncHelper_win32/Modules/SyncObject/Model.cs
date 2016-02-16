using System;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model.BannerCrawler;
using XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync;
using IFullyAutomaticSyncVmCtorParams = XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync.IViewModelConstructorParameters;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;
using SemiautomaticSyncModel = XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync.Model;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    public class Model : NotifyPropertyChanged, 
                         IBannerId,
                         IFullyAutomaticSyncVmCtorParams, 
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

        Guid IBannerId.Id { get { return ((IBannerId)this._programInfoVM).Id; } }

        private void Initialize( ProgramInfoViewModel programInfoVM, InstalledProgramViewModel installedProgramVM )
        {
            this._installedProgramVM = installedProgramVM;
            this._programInfoVM = programInfoVM;

            var modelCtorParams = (SemiautomaticSync.IModelConstructorParameters)this;
            this.SemiautomaticSyncModel = new SemiautomaticSyncModel( modelCtorParams );
        }

        public string InstallLocation { get { return this._installedProgramVM.InstallLocation; } }

        public bool /*IFullyAutomaticSyncVmCtorParams.*/

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

        public SemiautomaticSyncModel SemiautomaticSyncModel { get; private set; }

        public bool /*IFullyAutomaticSyncVmCtorParams.*/SupportsSteamCloud
        {
            get { return this._programInfoVM.SupportsSteamCloud; }
        }

        private InstalledProgramViewModel _installedProgramVM;
        private ProgramInfoViewModel _programInfoVM;
    }
#endregion
}
