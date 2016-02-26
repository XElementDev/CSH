using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.DataCreator.Data.Tools;
using XElement.CloudSyncHelper.DataCreator.Data.Games;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator
{
#region not unit-tested
    internal class DataManager : IPartImportsSatisfiedNotification
    {
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var syncData = new SyncData
            {
                ApplicationInfos = new List<AbstractApplicationInfo>()
            };
            syncData.ApplicationInfos.AddRange( this._games.GameLinkInfos );
            syncData.ApplicationInfos.AddRange( this._tools.ToolLinkInfos );

            this.SyncData = syncData;
        }

        public SyncData SyncData { get; private set; }

        [Import]
        private GameManager _games = null;

        [Import]
        private ToolManager _tools = null;
    }
#endregion
}
