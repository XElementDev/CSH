using System;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Service
{
#region not unit-tested
    public abstract class ClientServerBase
    {
        protected ClientServerBase()
        {
            this.Id = Guid.NewGuid();
        }


        protected void Log( string logMessage )
        {
            Logger.Log( this.Id.ToString(), logMessage );
        }


        protected Guid Id { get; private set; }
    }
#endregion
}
