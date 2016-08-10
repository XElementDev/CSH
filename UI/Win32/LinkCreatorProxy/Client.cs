using System;
using System.IO;
using System.IO.Pipes;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    //  --> https://stackoverflow.com/questions/13806153/example-of-named-pipes
    //      Last visited: 2016-08-03
    internal class Client : ClientServerBase
    {
        public Client() : base()
        {
            this.StartClient();
        }


        public override void DoWork( string message )
        {
            var writer = new StreamWriter( this._clientPipe );
            writer.WriteLine( message );
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
