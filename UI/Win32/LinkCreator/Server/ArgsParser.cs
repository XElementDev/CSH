using System.Linq;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Server
{
#region not unit-tested
    internal class ArgsParser
    {
        public ArgsParser( string[] args )
        {
            this.Parse( args );
        }


        public void Parse( string[] args )
        {
            if ( args.Length >= 1 )
            {
                this.PipeName = args.First();
            }
        }


        public string PipeName { get; private set; }
    }
#endregion
}
