namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Server
{
#region not unit-tested
    class Program
    {
        static void Main( string[] args )
        {
            var parser = new ArgsParser( args );

            var server = new Logic.Server( parser.PipeName );
            server.Start();
            server.StayAlive();
        }
    }
#endregion
}
