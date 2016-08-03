namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    class Program
    {
        static void Main( string[] args )
        {
            var server = new Server();
            if ( server.AnotherInstanceAlreadyRunning )
            {
                var client = new Client();
                client.Loop();
            }
            else
            {
                server.Loop();
            }
        }


        public const string PIPE_NAME = "8304D038-A445-4742-81A6-6855E54ADD64";
    }
#endregion
}
