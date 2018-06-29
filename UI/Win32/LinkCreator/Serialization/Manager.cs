using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Serialization
{
    public class Manager : IManager
    {
        public Manager()
        {
            this._formatter = new BinaryFormatter();
        }


        public ParametersDTO /*IManager.*/Deserialize( string serialized )
        {
            ParametersDTO deserialized = null;

            var bytes = Convert.FromBase64String( serialized );
            using ( var stream = new MemoryStream( bytes ) )
            {
                var deserializedObj = this._formatter.Deserialize( stream );
                deserialized = deserializedObj as ParametersDTO;
            }

            return deserialized;
        }


        public string /*IManager.*/Serialize( ParametersDTO parameters )
        {
            string serialized = null;

            using ( var stream = new MemoryStream() )
            {
                this._formatter.Serialize( stream, parameters );
                var bytes = stream.ToArray();
                serialized = Convert.ToBase64String( bytes );
            }

            return serialized;
        }


        private IFormatter _formatter;
    }
}
