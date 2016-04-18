using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution
{
#region not unit-tested
    internal class ToolLogic : IApplicationLogic
    {
        public ToolLogic( IApplicationInfo programInfo )
        {
            this._programInfo = programInfo;
        }

        public string /*IProgramLogic.*/PathToUserFolderContainer
        {
            get { return Path.Combine( "APPs", this._programInfo.FolderName ); }
        }

        private IApplicationInfo _programInfo;
    }
#endregion
}
