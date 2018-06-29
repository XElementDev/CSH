using NamedPipeWrapper;
using System;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Logic
{
#region not unit-tested
    public class Client
    {
        public Client( string pipeName )
        {
            this._waitForServerMessage = false;
            this.InitializeClientPipe( pipeName );
        }


        private void InitializeClientPipe( string pipeName )
        {
            this._client = new NamedPipeClient<string>( pipeName );
            this._client.AutoReconnect = false;
            this._client.Error += this.OnError;
            this._client.ServerMessage += this.OnServerMessage;
        }


        private void OnError( Exception exception )
        {
            throw exception;
        }


        private void OnServerMessage( NamedPipeConnection<string, string> connection, string message )
        {
            this._waitForServerMessage = false;
        }


        public void PlayBack( string message )
        {
            this.Start();
            this.PushMessage( message );
            this.Stop();
        }


        private void PushMessage( string message )
        {
            this._client.PushMessage( message );
            this.WaitForEndOfTransmission();
        }


        private void Start()
        {
            this._client.Start();
            this._client.WaitForConnection();
        }


        private void Stop()
        {
            this._client.Stop();
            this._client.WaitForDisconnection();
        }


        private void WaitForEndOfTransmission()
        {
            this._waitForServerMessage = true;
            while ( this._waitForServerMessage )
            {
            }
        }


        private NamedPipeClient<string> _client;
        private bool _waitForServerMessage;
    }
#endregion
}
