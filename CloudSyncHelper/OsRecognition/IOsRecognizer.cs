using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.OsRecognition
{
    internal interface IOsRecognizer
    {
        OsId? GetOsId();
    }
}
