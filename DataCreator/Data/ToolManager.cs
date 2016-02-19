using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
#region not unit-tested
    [Export]
    internal class ToolManager : IPartImportsSatisfiedNotification
    {
        [ImportMany( typeof( AbstractToolInfo ) )]
        public List<AbstractApplicationInfo> ToolLinkInfos { get; private set; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var gameLinkInfos = new List<AbstractApplicationInfo>();

            foreach ( var derivedAppInfo in this.ToolLinkInfos )
            {
                var baseAppInfo = new ToolInfo
                {
                    Definition = derivedAppInfo.Definition,
                    ApplicationName = derivedAppInfo.ApplicationName,
                    Id = derivedAppInfo.Id,
                    FolderName = derivedAppInfo.FolderName,
                    TechnicalNameMatcher = derivedAppInfo.TechnicalNameMatcher
                };
                gameLinkInfos.Add( baseAppInfo );
            }

            this.ToolLinkInfos = gameLinkInfos;
        }
    }
#endregion
}
