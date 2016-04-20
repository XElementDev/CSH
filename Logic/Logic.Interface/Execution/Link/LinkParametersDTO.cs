using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public class LinkParametersDTO
    {
        public IApplicationInfo ApplicationInfo { get; set; }

        public ILinkInfo LinkInfo { get; set; }

        public IPathVariables PathVariables { get; set; }
    }
}
