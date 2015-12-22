﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export]
    internal class GameManager : IPartImportsSatisfiedNotification
    {
        [ImportMany( typeof( AbstractGameInfo ) )]
        public List<AbstractProgramInfo> GameLinkInfos { get; private set; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var gameLinkInfos = new List<AbstractProgramInfo>();

            foreach ( var derivedGameInfo in this.GameLinkInfos )
            {
                var baseGameInfo = new GameInfo
                {
                    Configuration = derivedGameInfo.Configuration,
                    DisplayName = derivedGameInfo.DisplayName,
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
