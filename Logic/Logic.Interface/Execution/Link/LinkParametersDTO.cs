using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution.Link
{
#region not unit-tested
    public class LinkParametersDTO
    {
        public IApplicationInfo ApplicationInfo { get; set; }


        public ILinkInfo LinkInfo { get; set; }


        public PathVariablesDTO PathVariablesDTO { get; set; }
    }
#endregion
}
