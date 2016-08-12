using NamedPipeWrapper;
using System;
using System.Threading;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Logic
{
#region not unit-tested
    public class Client
    {
        public Client( string pipeName )
        {
            this._client = new NamedPipeClient<string>( pipeName );
            this._client.AutoReconnect = false;
            this._client.Error += OnError;
        }


        private void OnError( Exception exception )
        {
            throw exception;
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
            Thread.Sleep( 100 );
        }


        private NamedPipeClient<string> _client;
    }
#endregion
}
