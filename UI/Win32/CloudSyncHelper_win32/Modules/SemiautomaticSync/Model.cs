using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
#region not unit-tested
    public class Model : NotifyPropertyChanged
    {
        public Model( IModelConstructorParameters ctorParams )
        {
            this._isInstalled = ctorParams.IsInstalled;
            this._programInfoVM = ctorParams.ProgramInfoVM;

            this.SupportedOSsVM = new SupportedOperatingSystems.ViewModel( this._programInfoVM.OsConfigs );

            InitializeCommands();
        }

        public bool HasSuitableConfig { get { return this._programInfoVM.HasSuitableConfig; } }

        private void InitializeCommands()
        {
            this.LinkCommand = new DelegateCommand( this.LinkCommand_Execute, this.LinkCommand_CanExecute );
            this.MoveToCloudCommand = new DelegateCommand( this.MoveToCloudCommand_Execute,
                                                           this.MoveToCloudCommand_CanExecute );
            this.UnlinkCommand = new DelegateCommand( this.UnlinkCommand_Execute, this.UnlinkCommand_CanExecute );
        }

        public bool IsInCloud { get { return this._programInfoVM.IsInCloud; } }

        public bool IsLinked { get { return this._programInfoVM.IsLinked; } }

        public ICommand LinkCommand { get; private set; }
        private bool LinkCommand_CanExecute()
        {
            return this._isInstalled &&
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
            return this._isInstalled &&
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

        public SupportedOperatingSystems.ViewModel SupportedOSsVM { get; private set; }

        public ICommand UnlinkCommand { get; private set; }
        private bool UnlinkCommand_CanExecute()
        {
            return this.IsLinked;
        }
        private void UnlinkCommand_Execute()
        {
            this._programInfoVM.ExecutionLogic.Unlink();
            this.RaisePropertiesChanged();
        }

        private bool _isInstalled;
        private ProgramInfoViewModel _programInfoVM;
    }
#endregion
}
