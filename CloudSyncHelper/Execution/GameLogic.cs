using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Execution
{
#region not unit-tested
    internal class GameLogic : IProgramLogic
    {
        public GameLogic( IProgramInfo programInfo )
        {
            this._programInfo = programInfo;
        }

        public string /*IProgramLogic.*/PathToUserFolderContainer
        {
            get { return Path.Combine( "GAMEs", "PC", this._programInfo.FolderName, "SAVEs" ); }
        }

        private IProgramInfo _programInfo;
    }
#endregion
}
