using NamedPipeWrapper;
using System;
using System.IO;
using System.IO.Pipes;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Service
{
#region not unit-tested
    internal class Server : ClientServerBase
    {
        public Server( string pipeName ) : base()
        {
            this._executorFactory = new MkLinkExecutorFactory();
            this._pipeName = pipeName;

            InitializeServerPipe();
        }


        private void ClientConnected( NamedPipeConnection<string, string> connection )
        {
            this.Log( "Connected to server." );
        }


        private void ClientDisconnected( NamedPipeConnection<string, string> connection )
        {
            this.Log( "Disconnected from server." );
        }


        private void ClientMessage( NamedPipeConnection<string, string> connection, string message )
        {
            var logMessage = $"Received the following message from client: {message}";
            this.Log( logMessage );
            this.DoWork( message );
        }


        private void DoWork( string message )
        {
            //var parameters = new MessageParser().Parse( message );

            //if ( parameters == null )
            //{
            //    var error = String.Format( "Parsed message (of type {0}) must not be null.", 
            //                               typeof( ParametersDTO ).ToString() );
            //    throw new InvalidOperationException( error );
            //}
            //else
            //{
            //    Server.Log( parameters );
            //    this.Execute( parameters );
            //}
        }


        private void InitializeServerPipe()
        {
            this._serverPipe = new NamedPipeServer<string>( this._pipeName );
            this._serverPipe.ClientConnected += this.ClientConnected;
            this._serverPipe.ClientDisconnected += this.ClientDisconnected;
            this._serverPipe.ClientMessage += this.ClientMessage;
            this._serverPipe.Error += this.OnError;
        }


        private void OnError( Exception exception )
        {
            throw exception;
        }


        private void Start()
        {
            this._serverPipe.Start();
            this.Log( "Server started." );
        }


        public void StayAlive()
        {
            while ( true )
            {
            }
        }


        public bool TryStart()
        {
            var isAnotherInstanceAlreadyRunning = false;

            try
            {
                this.TryStart_Workaround();
                this.Start();
            }
            catch ( IOException )
            {
                isAnotherInstanceAlreadyRunning = true;
            }

            return !isAnotherInstanceAlreadyRunning;
        }


        //  --> 2016-08-10, Ian: Workaround because of 'https://github.com/acdvorak/named-pipe-wrapper/issues/7'.
        private void TryStart_Workaround()
        {
            new NamedPipeServerStream( this._pipeName ).Dispose();
        }


        private IFactory _executorFactory;
        private string _pipeName;
        private NamedPipeServer<string> _serverPipe;
    }
#endregion
}
