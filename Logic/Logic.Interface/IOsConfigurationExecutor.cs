using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IOsConfigurationExecutor
    {
        bool IsInCloud( IOsConfigurationInfo osConfig );

        bool IsLinked( IOsConfigurationInfo osConfig );

        void Link( IOsConfigurationInfo osConfig );

        void Unlink( IOsConfigurationInfo osConfig );
    }
}
