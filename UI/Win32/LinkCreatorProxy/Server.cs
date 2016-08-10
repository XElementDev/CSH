using System;
using System.IO;
using System.IO.Pipes;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    //  --> https://stackoverflow.com/questions/13806153/example-of-named-pipes
    //      Last visited: 2016-08-03
    internal class Server : ClientServerBase
    {
        public Server() : base()
        {
            this.AnotherInstanceAlreadyRunning = false;
            this.TryStartServer();
        }


        public bool AnotherInstanceAlreadyRunning { get; private set; }


        public override void DoWork( string message )
        {
            var parameters = new MessageParser().Parse( message );

            if ( parameters == null )
            {
                var error = String.Format( "Parsed message (of type {0}) must not be null.", 
                                           typeof( ParametersDTO ).ToString() );
                throw new InvalidOperationException( error );
            }
            else
            {
                this.Execute( parameters );
            }
        }


        private void Execute( ParametersDTO parameters )
        {
            var executor = this._executorFactory.Get( parameters );
            executor.Execute();
            this.Loop();
        }


        private void Loop()
        {
            this._server.WaitForConnection();
            StreamReader reader = new StreamReader( this._server );
            while ( true )
            {
                var line = reader.ReadLine();
                this.DoWork( line );
                // TODO fix cascading endless loop
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
