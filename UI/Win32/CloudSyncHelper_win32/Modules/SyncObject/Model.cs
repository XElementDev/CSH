using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model.BannerCrawler;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;
using SupportedOperatingSystemsViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SupportedOperatingSystems.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    public class Model : NotifyPropertyChanged, 
                         IBannerId
    {
        public Model( ProgramInfoViewModel programInfoVM ) : this( programInfoVM, null ) { }
        public Model( ProgramInfoViewModel programInfoVM, 
                      InstalledProgramViewModel installedProgramVM )
        {
            this._installedProgramVM = installedProgramVM;
            this._programInfoVM = programInfoVM;

            this.SupportedOSsVM = new SupportedOperatingSystemsViewModel( this._programInfoVM.OsConfigs );
            InitializeCommands();
        }

        public string DisplayName { get { return this._programInfoVM.DisplayName; } }

        public bool HasSuitableConfig { get { return this._programInfoVM.HasSuitableConfig; } }

        Guid IBannerId.Id { get { return ((IBannerId)this._programInfoVM).Id; } }

        private void InitializeCommands()
        {
            this.LinkCommand = new DelegateCommand( this.LinkCommand_Execute, this.LinkCommand_CanExecute );
            this.MoveToCloudCommand = new DelegateCommand( this.MoveToCloudCommand_Execute,
                                                           this.MoveToCloudCommand_CanExecute );
            this.UnlinkCommand = new DelegateCommand( this.UnlinkCommand_Execute, this.UnlinkCommand_CanExecute );
        }

        public string InstallLocation { get { return this._installedProgramVM.InstallLocation; } }

        public bool IsInCloud { get { return this._programInfoVM.IsInCloud; } }

        public bool IsInstalled { get { return this._installedProgramVM != null; } }

        public bool IsLinked
        {
            get
            {
                var linkingDoneByCloudProvider = this.IsInstalled && this.SupportsSteamCloud;
                return this._programInfoVM.IsLinked || linkingDoneByCloudProvider;
            }
        }

        public ICommand LinkCommand { get; private set; }
        private bool LinkCommand_CanExecute()
        {
            return this.IsInstalled &&
                this.HasSuitableConfig &&
                this.IsInCloud &&
                !this.IsLinked;
        }
        private void LinkCommand_Execute()
        {
            this._programInfoVM.ExecutionLogic.Link();
            this.RaisePropertiesChanged();
        }

        public ICommand MoveToCloudCommand { get; private set; }
        private bool MoveToCloudCommand_CanExecute()
        {
            return this.IsInstalled &&
                this.HasSuitableConfig &&
                !this.IsInCloud;
        }
        private void MoveToCloudCommand_Execute()
        {
            this._programInfoVM.ExecutionLogic.MoveToCloud();
            this.RaisePropertiesChanged();
        }

        public IEnumerable<Tuple<string, string>> PathMap
        {
            get
            {
                var pathMap = new List<Tuple<string, string>>();
                foreach ( var osConfig in this._programInfoVM.ExecutionLogic.Config )
                {
                    pathMap.Add( new Tuple<string, string>( osConfig.LinkPath, osConfig.TargetPath ) );
                }
                return pathMap;
            }
        }

        private void RaisePropertiesChanged()
        {
            this.RaisePropertyChanged( "IsInCloud" );
            this.RaisePropertyChanged( "IsLinked" );
            (this.LinkCommand as DelegateCommand).RaiseCanExecuteChanged();
            (this.MoveToCloudCommand as DelegateCommand).RaiseCanExecuteChanged();
            (this.UnlinkCommand as DelegateCommand).RaiseCanExecuteChanged();
        }

        public SupportedOperatingSystemsViewModel SupportedOSsVM { get; private set; }

        public bool SupportsSteamCloud { get { return this._programInfoVM.SupportsSteamCloud; } }

        public ICommand UnlinkCommand { get; private set; }
        private bool UnlinkCommand_CanExecute()
        {
            return this.IsLinked && !this.SupportsSteamCloud;
        }
        private void UnlinkCommand_Execute()
        {
            this._programInfoVM.ExecutionLogic.Unlink();
            this.RaisePropertiesChanged();
        }

        private InstalledProgramViewModel _installedProgramVM;
        private ProgramInfoViewModel _programInfoVM;
    }
#endregion
}
