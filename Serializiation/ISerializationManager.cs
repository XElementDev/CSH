using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.Serializiation
{
    public interface ISerializationManager
    {
        SyncData Deserialize();
        void Serialize( SyncData target );
        string Uri { get; set; }
    }
}
