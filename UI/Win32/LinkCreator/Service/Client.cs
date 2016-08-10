﻿using NamedPipeWrapper;
using System;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Service
{
#region not unit-tested
    internal class Client : ClientServerBase
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
            var logMessage = $"Pushing the following message to the server: {message}";
            Logger.Log( this.Id.ToString(), logMessage );
        }


        private void Start()
        {
            this._client.Start();
            this._client.WaitForConnection();
            Logger.Log( this.Id.ToString(), "Client connected." );
        }


        private void Stop()
        {
            this._client.Stop();
            this._client.WaitForDisconnection();
            Logger.Log( this.Id.ToString(), "Client disconnected." );
        }


        private NamedPipeClient<string> _client;
    }
#endregion
}