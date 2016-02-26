using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
#region not unit-tested
    internal abstract class AbstractManager<T> where T : AbstractApplicationInfo, new()
    {
        protected abstract IEnumerable<AbstractApplicationInfo> LinkInfos { get; set; }

        protected void PrepareLinkInfos()
        {
            var linkInfos = new List<AbstractApplicationInfo>();

            foreach ( var derivedAppInfo in this.LinkInfos )
            {
                var baseAppInfo = new T
                {
                    Definition = derivedAppInfo.Definition,
                    ApplicationName = derivedAppInfo.ApplicationName,
                    Id = derivedAppInfo.Id,
                    FolderName = derivedAppInfo.FolderName,
                    TechnicalNameMatcher = derivedAppInfo.TechnicalNameMatcher
                };
                linkInfos.Add( baseAppInfo );
            }

            this.LinkInfos = linkInfos;
        }
    }
#endregion
}
