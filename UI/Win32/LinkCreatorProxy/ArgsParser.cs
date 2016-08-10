using System.Linq;

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
                serialized = args.First();
            }

            return serialized;
        }
    }
#endregion
}
