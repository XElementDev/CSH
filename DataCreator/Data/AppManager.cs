using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
    [Export]
    internal class AppManager : IPartImportsSatisfiedNotification
    {
        [ImportMany( typeof( AppInfo ) )]
        public List<AbstractProgramInfo> AppLinkInfos { get; private set; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var gameLinkInfos = new List<AbstractProgramInfo>();

            foreach ( var derivedAppInfo in this.AppLinkInfos )
            {
                var baseAppInfo = new AppInfo
                {
                    DisplayName = derivedAppInfo.DisplayName,
                    FolderName = derivedAppInfo.FolderName,
                    OsConfigs = derivedAppInfo.OsConfigs,
                    TechnicalNameMatcher = derivedAppInfo.TechnicalNameMatcher
                };
                gameLinkInfos.Add( baseAppInfo );
            }

            this.AppLinkInfos = gameLinkInfos;
        }
    }
}
