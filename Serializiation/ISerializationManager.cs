using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Serializiation
{
    public interface ISerializationManager
    {
        ISyncData Deserialize();
        void Serialize( ISyncData target );
        string Uri { get; set; }
    }
}
