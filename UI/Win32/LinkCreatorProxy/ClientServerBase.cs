using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    internal abstract class ClientServerBase
    {
        public ClientServerBase()
        {
            this._executorFactory = new MkLinkExecutorFactory();
        }


        public abstract void DoWork( string message );


        protected IFactory _executorFactory;
    }
#endregion
}
