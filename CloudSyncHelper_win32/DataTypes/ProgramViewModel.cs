using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    public class ProgramViewModel : ViewModelBase
    {
        public ProgramViewModel( IEventAggregator eventAggregator )
        {
            this._eventAggregator = eventAggregator;

            this.LinkCommand = new DelegateCommand( this.LinkCommand_Execute, this.LinkCommand_CanExecute );
            this.UnlinkCommand = new DelegateCommand( () => { }, this.UnlinkCommand_CanExecute );
        }

        public string DisplayName { get { return this.ProgramInfoVM.DisplayName; } }

        public bool HasSuitableConfig { get { return this.ProgramInfoVM.HasSuitableConfig; } }

        public InstalledProgramViewModel InstalledProgram { get; set; }

        public bool IsInstalled { get { return this.InstalledProgram != null; } }

        public bool IsLinked { get { return this.ProgramInfoVM.IsLinked; } }

        public ICommand LinkCommand { get; private set; }
        private bool LinkCommand_CanExecute()
        {
            return this.IsInstalled &&
                this.HasSuitableConfig &&
                !this.IsLinked;
        }
        private void LinkCommand_Execute()
        {
            this.ProgramInfoVM.ExecutionLogic.Link();
        }

        public IEnumerable<Tuple<string, string>> PathMap
        {
            get
            {
                return new List<Tuple<string, string>> { new Tuple<string, string>( "key", "value" ) };
            }
        }

        public ProgramInfoViewModel ProgramInfoVM { get; set; }

        public ICommand UnlinkCommand { get; private set; }
        private bool UnlinkCommand_CanExecute()
        {
            return this.IsLinked;
        }

        private IEventAggregator _eventAggregator;
    }
#endregion
}
