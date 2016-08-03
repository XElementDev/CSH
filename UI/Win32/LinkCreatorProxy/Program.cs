namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    class Program
    {
        ////  --> https://stackoverflow.com/questions/502303/how-do-i-programmatically-get-the-guid-of-an-application-in-net2-0
        ////      Last visited: 2016-07-12
        //private static string Uid
        //{
        //    get
        //    {
        //        var assembly = Assembly.GetExecutingAssembly();
        //        var guid = assembly.GetType().GUID;
        //        return guid.ToString();
        //    }
        //}


        ////  --> https://stackoverflow.com/questions/6486195/ensuring-only-one-application-instance
        ////      Last visited: 2016-07-12
        //[STAThread]
        //static void Main( string[] args )
        //{
        //    bool initiallyOwned = false;
        //    bool createdNew;
        //    _mutex = new Mutex( initiallyOwned, Uid, out createdNew );

        //    if ( createdNew )
        //    {
        //        new LogicProxy().Do( args );
        //        Console.ReadKey();
        //    }
        //    else
        //    {
        //        Console.WriteLine( "Application already running!" );
        //    }
        //}


        //private static Mutex _mutex;

        //  --> https://stackoverflow.com/questions/13806153/example-of-named-pipes
        //      Last visited: 2016-07-12
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
            //StartServer();
            //Task.Delay( 1000 ).Wait();


            ////Client
            //var client = new NamedPipeClientStream( "PipesOfPiece" );
            //client.Connect();
            //StreamReader reader = new StreamReader( client );
            //StreamWriter writer = new StreamWriter( client );

            //while ( true )
            //{
            //    string input = Console.ReadLine();
            //    if ( String.IsNullOrEmpty( input ) ) break;
            //    writer.WriteLine( input );
            //    writer.Flush();
            //    Console.WriteLine( reader.ReadLine() );
            //}
        }


        //static void StartServer()
        //{
        //    Task.Factory.StartNew( () =>
        //    {
        //        var server = new NamedPipeServerStream( "PipesOfPiece" );
        //        server.WaitForConnection();
        //        StreamReader reader = new StreamReader( server );
        //        StreamWriter writer = new StreamWriter( server );
        //        while ( true )
        //        {
        //            var line = reader.ReadLine();
        //            writer.WriteLine( String.Join( "", line.Reverse() ) );
        //            writer.Flush();
        //        }
        //    } );
        //}


        public const string PIPE_NAME = "8304D038-A445-4742-81A6-6855E54ADD64";
    }
#endregion
}
