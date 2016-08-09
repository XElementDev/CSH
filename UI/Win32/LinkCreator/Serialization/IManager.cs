using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Serialization
{
    public interface IManager
    {
        ParametersDTO Deserialize( string serialized );


        string Serialize( ParametersDTO parameters );
    }
}
