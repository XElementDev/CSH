using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.DataCreator.Data;
using XElement.CloudSyncHelper.DataCreator.Data.Apps;
using XElement.CloudSyncHelper.DataCreator.Data.Games;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator
{
    internal class DataManager : IPartImportsSatisfiedNotification
    {
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var syncData = new SyncData
            {
                ProgramInfos = new List<AbstractProgramInfo>()
            };
            syncData.ProgramInfos.AddRange( this._apps.AppLinkInfos );
            syncData.ProgramInfos.AddRange( this._games.GameLinkInfos );

            this.SyncData = syncData;
        }

        public SyncData SyncData { get; private set; }

        [Import]
        private AppManager _apps = null;

        [Import]
        private GameManager _games = null;
    }
}
