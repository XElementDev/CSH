using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IOsConfigurationExecutor
    {
        bool IsInCloud( IOsConfiguration osConfig );

        bool IsLinked( IOsConfiguration osConfig );

        void Link( IOsConfiguration osConfig );

        void Unlink( IOsConfiguration osConfig );
    }
}
