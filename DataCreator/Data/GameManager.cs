using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export]
    internal class GameManager : IPartImportsSatisfiedNotification
    {
        [ImportMany( typeof( AbstractGameInfo ) )]
        public List<AbstractApplicationInfo> GameLinkInfos { get; private set; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var gameLinkInfos = new List<AbstractApplicationInfo>();

            foreach ( var derivedGameInfo in this.GameLinkInfos )
            {
                var baseGameInfo = new GameInfo
                {
                    Definition = derivedGameInfo.Definition,
                    ApplicationName = derivedGameInfo.ApplicationName,
                    FolderName = derivedGameInfo.FolderName,
                    Id = derivedGameInfo.Id,
                    TechnicalNameMatcher = derivedGameInfo.TechnicalNameMatcher
                };
                gameLinkInfos.Add( baseGameInfo );
            }

            this.GameLinkInfos = gameLinkInfos;
        }
    }
}
