using System.IO;
using System.Xml.Serialization;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.Serializiation
{
#region not unit-tested
    public class SerializationManager : ISerializationManager
    {
        public SerializationManager( string uri )
        {
            this.Uri = uri;

            this._serializer = new XmlSerializer( typeof( SyncData ) );
        }

        public SyncData /*ISerializationManager.*/Deserialize()
        {
            SyncData result = null;

            using ( var fileStream = new FileStream( this.Uri, FileMode.Open ) )
            {
                var obj = this._serializer.Deserialize( fileStream );
                result = obj as SyncData;
            }

            return result;
        }

        public void /*ISerializationManager.*/Serialize( SyncData target )
        {
            using ( var fileStream = new FileStream( this.Uri, FileMode.Create ) )
            {
                this._serializer.Serialize( fileStream, target );
            }
        }

        public string /*ISerializationManager.*/Uri { get; set; }

        private XmlSerializer _serializer;
    }
#endregion
}
