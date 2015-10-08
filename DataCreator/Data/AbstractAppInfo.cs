using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.DataCreator.Model;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
#region not unit-tested
    internal abstract class AbstractAppInfo : AppInfo, IPartImportsSatisfiedNotification
    {
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.OnImportsSatisfied();
        }
        protected abstract void OnImportsSatisfied();

        [Import]
        protected ConfigurationFactory _configFactory = null;
    }
#endregion
}
