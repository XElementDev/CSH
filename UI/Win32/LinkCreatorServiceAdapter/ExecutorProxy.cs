using System;
using System.Diagnostics;
using System.IO;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;
using XElement.CloudSyncHelper.UI.Win32.LinkCreator.Serialization;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreatorServiceAdapter
{
#region not unit-tested
    internal class ExecutorProxy : IExecutor
    {
        public ExecutorProxy( ParametersDTO parameters )
        {
            this._parameters = parameters;
            this._serializationManager = new Manager();
        }


        private string Arguments
        {
            get { return this._serializationManager.Serialize( this._parameters ); }
        }


        public void Execute()
        {
            var process = new Process();
            process.StartInfo.FileName = this.PathToLinkCreatorSvcExe;
            process.StartInfo.Arguments = this.Arguments;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }


        private string PathToLinkCreatorSvcExe
        {
            get
            {
                return Path.Combine( Environment.CurrentDirectory, 
                                     SERVICE_FILE_NAME );
            }
        }


        private const string SERVICE_FILE_NAME = "CSH_LinkCreatorProxy_win32.exe";


        private ParametersDTO _parameters;
        private IManager _serializationManager;
    }
#endregion
}
