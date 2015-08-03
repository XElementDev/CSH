using XElement.CloudSyncHelper.DataTypes;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32
{
    public class ProgramViewModel : ViewModelBase
    {
        public string DisplayName { get { return this._programInfo.DisplayName; } }

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

        public bool IsInstalled { get { return true; } }

        private IProgramInfo _programInfo;
        public IProgramInfo ProgramInfo
        {
            get { return this._programInfo; }
            set
            {
                this._programInfo = value;
                this.ExecutionLogic = new ExecutionLogic( this.ProgramInfo );
                this.RaisePropertyChanged( "DisplayName" );
            }
        }
    }
}
