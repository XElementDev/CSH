using XElement.CloudSyncHelper.Logic.Execution.MkLink;
using XElement.CloudSyncHelper.UI.Win32.LinkCreator.Serialization;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    internal class ArgsParser
    {
        public ArgsParser() { }


        public string Parse( string[] args )
        {
            string serialized = null;

            if ( args.Length >= 1 )
            {
                serialized = args[1];
            }

            return serialized;
        }
    }
#endregion
}
