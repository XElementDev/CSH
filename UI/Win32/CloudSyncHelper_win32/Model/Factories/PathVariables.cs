using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.Win32.Model.Factories
{
#region not unit-tested
    [Export( typeof( Logic.PathVariablesDTO ) )]
    internal class PathVariables : Logic.PathVariablesDTO, IPartImportsSatisfiedNotification
    {
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.PathToSyncFolder = this._config.PathToSyncFolder;
            this.UplayUserName = this._config.UplayAccountName;
            this.UserName = this._config.UserName;
        }

        [Import]
        private IConfig _config = null;
    }
#endregion
}
