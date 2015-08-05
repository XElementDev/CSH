using Microsoft.Practices.Prism.Commands;
using System;
using System.Windows.Input;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    public class ProgramViewModel : ViewModelBase
    {
        public ProgramViewModel( IConfig appConfig )
        {
            this._appConfig = appConfig;

            this.LinkCommand = new DelegateCommand( () => { }, this.LinkCommand_CanExecute );
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

        // TODO: Add logic for IsLinked
        public bool IsLinked { get { return false; } }

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
    }
#endregion
}
