using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    //  --> https://stackoverflow.com/questions/13806153/example-of-named-pipes
    //      Last visited: 2016-08-03
    internal class Server
    {
        public Server( /*string message*/ )
        {
            this.AnotherInstanceAlreadyRunning = false;
            this.TryStartServer();
        }


        public bool AnotherInstanceAlreadyRunning { get; private set; }


        public void Loop()
        {
            this._server.WaitForConnection();
            StreamReader reader = new StreamReader( this._server );
            while ( true )
            {
                var line = reader.ReadLine();
                if ( line != null )
                {
                    Console.WriteLine( String.Join( "", line.Reverse() ) );
                }
            }
        }


        private void StartServer()
        {
            this._server = new NamedPipeServerStream( Program.PIPE_NAME );
            Console.WriteLine( "Server up and running." );
        }


        private void TryStartServer()
        {
            try
            {
                this.StartServer();
            }
            catch ( IOException )
            {
                this.AnotherInstanceAlreadyRunning = true;
            }
        }


        private NamedPipeServerStream _server;
    }
#endregion
}
