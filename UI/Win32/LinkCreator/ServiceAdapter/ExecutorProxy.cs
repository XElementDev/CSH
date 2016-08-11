using XElement.CloudSyncHelper.Logic.Execution.MkLink;
using XElement.CloudSyncHelper.UI.Win32.LinkCreator.Serialization;
using XElement.CloudSyncHelper.UI.Win32.LinkCreator.Service;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.ServiceAdapter
{
#region not unit-tested
    internal class ExecutorProxy : IExecutor
    {
        public ExecutorProxy( ParametersDTO parameters )
        {
            this._parameters = parameters;
            this._serializationManager = new Manager();
        }


        public void Execute()
        {
            var server = new ServerAdapter();
            if ( server.CanStart() )
            {
                server.Launch();
            }

            var client = new Client( ClientServer.PIPE_NAME );
            client.PlayBack( this.Message );
        }


        private string Message
        {
            get { return this._serializationManager.Serialize( this._parameters ); }
        }


        private ParametersDTO _parameters;
        private IManager _serializationManager;
    }
#endregion
}
