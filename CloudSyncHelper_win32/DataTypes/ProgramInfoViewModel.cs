using System;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    public class ProgramInfoViewModel
    {
        public ProgramInfoViewModel( IProgramInfo programInfo, IConfig config )
        {
            this._config = config;
            this._programInfo = programInfo;

            InitializeExecutionLogic( programInfo );
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
                return displayName;
            }
        }

        private ExecutionLogic _executionLogic;
        public ExecutionLogic ExecutionLogic
        {
            get { return this._executionLogic; }
            private set
            {
                this._executionLogic = value;
                //this.UnlinkCommand = new DelegateCommand( this.ExecutionLogic.Unlink, this.UnlinkCommand_CanExecute );
                //this.RaisePropertyChanged( "HasSuitableConfig" );
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

        private void InitializeExecutionLogic( IProgramInfo programInfo )
        {
            var pathVariables = new PathVariablesDTO
            {
                PathToSyncFolder = this._config.PathToSyncFolder,
                UplayUserName = this._config.UplayAccountName,
                UserName = this._config.UserName
            };
            this.ExecutionLogic = new ExecutionLogic( programInfo, pathVariables );
        }

        public bool IsLinked
        {
            get
            {
                return this.ExecutionLogic.LinkPaths
                    .All( path => new SymbolicLinkHelper().IsSymbolicLink( path ) );
            }
        }

        public string TechnicalNameMatcher { get { return this._programInfo.TechnicalNameMatcher; } }

        private IConfig _config;
        private IProgramInfo _programInfo;
    }
#endregion
}
