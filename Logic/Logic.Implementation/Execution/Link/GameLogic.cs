using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution.Link
{
#region not unit-tested
    internal class GameLogic : IApplicationLogic
    {
        public GameLogic( IApplicationInfo appInfo )
        {
            this._appInfo = appInfo;
        }

        public string /*IProgramLogic.*/PathToUserFolderContainer
        {
            get { return Path.Combine( "GAMEs", "PC", this._appInfo.FolderName, "SAVEs" ); }
        }

        private IApplicationInfo _appInfo;
    }
#endregion
}
