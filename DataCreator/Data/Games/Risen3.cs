using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class Risen3 : GameInfo
    {
        [ImportingConstructor]
        public Risen3()
        {
            this.DisplayName = "Risen 3 - Titan Lords";
            this.FolderName = "Risen 2014 [Risen 3 - Titan Lords]";
            this.OsConfigs = new List<OsConfiguration>()
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Risen 3 - Titan Lords";
        }
    }
}
