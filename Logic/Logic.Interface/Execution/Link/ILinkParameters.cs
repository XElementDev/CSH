using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public interface ILinkParameters
    {
        IApplicationInfo ApplicationInfo { get; }

        ILinkInfo LinkInfo { get; }

        IPathVariables PathVariables { get; }
    }
}
