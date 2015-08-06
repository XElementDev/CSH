using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using System;
using System.Linq;
using System.Windows.Input;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Events;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    public class ProgramViewModel : ViewModelBase
    {
        public ProgramViewModel( IEventAggregator eventAggregator, IConfig appConfig )
        {
            this._appConfig = appConfig;
            this._eventAggregator = eventAggregator;

            this.LinkCommand = new DelegateCommand( this.LinkCommand_Execute, this.LinkCommand_CanExecute );
            this.UnlinkCommand = new DelegateCommand( () => { }, this.UnlinkCommand_CanExecute );
        }

        public string DisplayName
        {
            get
            {
                var displayName = String.Empty;
                if ( this._programInfo != null )
                {
                    displayName = this._programInfo.DisplayName;
                }
                else if ( this._installedProgram.DisplayName != null )
                {
                    displayName = this._installedProgram.DisplayName;
                }
                return displayName;
            }
        }

        private ExecutionLogic _executionLogic;
        private ExecutionLogic ExecutionLogic
        {
            get { return this._executionLogic; }
            set
            {
                this._executionLogic = value;
                this.UnlinkCommand = new DelegateCommand( this.ExecutionLogic.Unlink, this.UnlinkCommand_CanExecute );
                this.RaisePropertyChanged( "HasSuitableConfig" );
            }
        }

        public bool HasSuitableConfig
        {
            get
            {
                return this.ExecutionLogic != null && 
                    this.ExecutionLogic.HasSuitableConfig();
            }
        }

        private InstalledProgramViewModel _installedProgram;
        public InstalledProgramViewModel InstalledProgram
        {
            get { return this._installedProgram; }
            set
            {
                this._installedProgram = value;
            }
        }

        public bool IsInstalled { get { return this._installedProgram != null; } }

        public bool IsLinked
        {
            get
            {
                return this.ExecutionLogic.LinkPaths
                    .All( path => new SymbolicLinkHelper().IsSymbolicLink( path ) );
            }
        }

        public string LinkPaths
        {
            get
            {
                if ( this.ExecutionLogic == null )
                    return String.Empty;
                return String.Join( Environment.NewLine, this.ExecutionLogic.LinkPaths );
            }
        }

        public ICommand LinkCommand { get; private set; }
        private bool LinkCommand_CanExecute()
        {
            return this.IsInstalled &&
                this.HasSuitableConfig &&
                !this.IsLinked;
        }
        private void LinkCommand_Execute()
        {
            this.ExecutionLogic.Link();
            var output = String.Join( Environment.NewLine, this.ExecutionLogic.StandardOutputs );
            this._eventAggregator.GetEvent<StandardOutputChanged>().Publish( output );
        }

        private IProgramInfo _programInfo;
        public IProgramInfo ProgramInfo
        {
            get { return this._programInfo; }
            set
            {
                this._programInfo = value;
                var pathVariables = new PathVariablesDTO
                {
                    PathToSyncFolder = this._appConfig.PathToSyncFolder,
                    UplayUserName = this._appConfig.UplayAccountName,
                    UserName = this._appConfig.UserName
                };
                this.ExecutionLogic = new ExecutionLogic( this.ProgramInfo, pathVariables );
                this.RaisePropertyChanged( "DisplayName" );
            }
        }

        public string TargetPaths
        {
            get
            {
                if ( this.ExecutionLogic == null )
                    return String.Empty;
                return String.Join( Environment.NewLine, this.ExecutionLogic.TargetPaths );
            }
        }

        public ICommand UnlinkCommand { get; private set; }
        private bool UnlinkCommand_CanExecute()
        {
            return this.IsLinked;
        }

        private IConfig _appConfig;
        private IEventAggregator _eventAggregator;
    }
#endregion
}
