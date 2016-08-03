using System;
using System.IO;
using System.IO.Pipes;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    internal class Client
    {
        public Client( /*string message*/ )
        {
            this.StartClient();
        }


        public void Loop()
        {
            StreamWriter writer = new StreamWriter( this._clientPipe );

            while ( true )
            {
                string input = Console.ReadLine();
                if ( String.IsNullOrEmpty( input ) ) break;
                writer.WriteLine( input );
                writer.Flush();
            }
        }


        private void StartClient()
        {
            var client = new NamedPipeClientStream( Program.PIPE_NAME );
            client.Connect();
            this._clientPipe = client;
            Console.WriteLine( "Client connected." );
        }


        private Stream _clientPipe;
    }
#endregion
}
