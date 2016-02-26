using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Tools
{
#region not unit-tested
    [Export]
    internal sealed class ToolManager : AbstractManager<ToolInfo>, 
                                        IPartImportsSatisfiedNotification
    {
        [ImportMany( typeof( AbstractToolInfo ) )]
        protected override IEnumerable<AbstractApplicationInfo> LinkInfos { get; set; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.PrepareLinkInfos();
        }

        public IEnumerable<AbstractApplicationInfo> ToolLinkInfos
        {
            get { return this.LinkInfos; }
        }
    }
#endregion
}
