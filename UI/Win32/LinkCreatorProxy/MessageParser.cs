using XElement.CloudSyncHelper.Logic.Execution.MkLink;
using XElement.CloudSyncHelper.UI.Win32.LinkCreator.Serialization;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    internal class MessageParser
    {
        public MessageParser()
        {
            this._serializationManager = new Manager();
        }


        public ParametersDTO Parse( string serialized )
        {
            ParametersDTO deserialized = null;

            if ( serialized != null )
            {
                deserialized = this._serializationManager.Deserialize( serialized );
            }

            return deserialized;
        }


        private IManager _serializationManager;
    }
#endregion
}
