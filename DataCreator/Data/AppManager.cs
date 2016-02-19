using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
    [Export]
    internal class AppManager : IPartImportsSatisfiedNotification
    {
        [ImportMany( typeof( AbstractAppInfo ) )]
        public List<AbstractApplicationInfo> AppLinkInfos { get; private set; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var gameLinkInfos = new List<AbstractApplicationInfo>();

            foreach ( var derivedAppInfo in this.AppLinkInfos )
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

            this.AppLinkInfos = gameLinkInfos;
        }
    }
}
