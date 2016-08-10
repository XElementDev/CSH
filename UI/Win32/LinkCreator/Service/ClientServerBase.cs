using System;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Service
{
#region not unit-tested
    internal abstract class ClientServerBase
    {
        public ClientServerBase()
        {
            this.Id = Guid.NewGuid();
        }


        protected Guid Id { get; private set; }
    }
#endregion
}
