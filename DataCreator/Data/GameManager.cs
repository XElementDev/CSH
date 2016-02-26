using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
#region not unit-tested
    [Export]
    internal sealed class GameManager : AbstractManager<GameInfo>, 
                                        IPartImportsSatisfiedNotification
    {
        public IEnumerable<AbstractApplicationInfo> GameLinkInfos
        {
            get { return this.LinkInfos; }
        }

        [ImportMany( typeof( AbstractGameInfo ) )]
        protected override IEnumerable<AbstractApplicationInfo> LinkInfos { get; set; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.PrepareLinkInfos();
        }
    }
#endregion
}
