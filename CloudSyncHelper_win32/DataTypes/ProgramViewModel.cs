using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using XElement.Common.UI;
using SupportedOperatingSystemsViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SupportedOperatingSystems.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    public class ProgramViewModel : ViewModelBase
    {
        public ProgramViewModel( IEventAggregator eventAggregator )
        {
            this._eventAggregator = eventAggregator;

            this.LinkCommand = new DelegateCommand( this.LinkCommand_Execute, this.LinkCommand_CanExecute );
            this.UnlinkCommand = new DelegateCommand( this.UnlinkCommand_Execute, this.UnlinkCommand_CanExecute );
        }

        public string DisplayName { get { return this.ProgramInfoVM.DisplayName; } }

        public bool HasSuitableConfig { get { return this.ProgramInfoVM.HasSuitableConfig; } }

        public InstalledProgramViewModel InstalledProgram { get; set; }

        public bool IsInCloud { get { return this.ProgramInfoVM.IsInCloud; } }

        public bool IsInstalled { get { return this.InstalledProgram != null; } }

        public bool IsLinked { get { return this.ProgramInfoVM.IsLinked; } }

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
            this.ProgramInfoVM.ExecutionLogic.Link();
            this.RaisePropertiesChanged();
        }

        public IEnumerable<Tuple<string, string>> PathMap
        {
            get
            {
                var pathMap = new List<Tuple<string, string>>();
                foreach ( var osConfig in this.ProgramInfoVM.ExecutionLogic.Config )
                {
                    pathMap.Add( new Tuple<string, string>( osConfig.Link, osConfig.Target ) );
                }
                return pathMap;
            }
        }

        private ProgramInfoViewModel _programInfoVM;
        public ProgramInfoViewModel ProgramInfoVM
        {
            get { return this._programInfoVM; }
            set
            {
                this._programInfoVM = value;
                this.SupportedOSsVM = new SupportedOperatingSystemsViewModel( this.ProgramInfoVM.OsConfigs );
            }
        }

        private void RaisePropertiesChanged()
        {
            this.RaisePropertyChanged( "IsLinked" );
            (this.LinkCommand as DelegateCommand).RaiseCanExecuteChanged();
            (this.UnlinkCommand as DelegateCommand).RaiseCanExecuteChanged();
        }

        public SupportedOperatingSystemsViewModel SupportedOSsVM { get; private set; }

        public ICommand UnlinkCommand { get; private set; }
        private bool UnlinkCommand_CanExecute()
        {
            return this.IsLinked;
        }
        private void UnlinkCommand_Execute()
        {
            this.ProgramInfoVM.ExecutionLogic.Unlink();
            this.RaisePropertiesChanged();
        }

        private IEventAggregator _eventAggregator;
    }
#endregion
}
