using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;

namespace XElement.CloudSyncHelper.UI.Win32.Model.Factories
{
#region not unit-tested
    [Export( typeof( IPathVariables ) )]
    internal class PathVariables : IPathVariables, IPartImportsSatisfiedNotification
    {
        public string PathToSyncFolder { get; private set; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.PathToSyncFolder = this._config.PathToSyncFolder;
            this.UplayUserName = this._config.UplayAccountName;
            this.UserName = this._config.UserName;
        }

        public string UplayUserName { get; private set; }

        public string UserName { get; private set; }

        [Import]
        private IConfig _config = null;
    }
#endregion
}
