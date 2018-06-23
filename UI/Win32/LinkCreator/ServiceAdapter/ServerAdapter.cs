using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.ServiceAdapter
{
#region not unit-tested
    internal class ServerAdapter
    {
        public ServerAdapter() { }


        public bool CanStart()
        {
            var isAnotherInstanceAlreadyRunning = false;

            try
            {
                this.CanStart_Workaround();
            }
            catch /*( IOException )*/
            {
                isAnotherInstanceAlreadyRunning = true;
            }

            return !isAnotherInstanceAlreadyRunning;
        }


        //  --> 2016-08-10, Ian: 
        //      Workaround because of 'https://github.com/acdvorak/named-pipe-wrapper/issues/7'.
        private void CanStart_Workaround()
        {
            new NamedPipeServerStream( ClientServer.PIPE_NAME ).Dispose();
        }


        public void Launch()
        {
            var process = new Process();
            process.StartInfo.FileName = this.PathToLinkCreatorSvcExe;
            process.StartInfo.Arguments = ClientServer.PIPE_NAME;
            process.StartInfo.CreateNoWindow = true;    // TODO check why a window is created
            process.Start();    // TODO handle if user does not allow admin rights
            // TODO: fix link creating, currently symlinks do not point to the correct file (and cannot be opened)
        }


        private string PathToLinkCreatorSvcExe
        {
            get
            {
                var serviceFileName = new Server.AssemblyInfoAccessor().AssemblyName + ".exe";
                return Path.Combine( Environment.CurrentDirectory,
                                     serviceFileName );
            }
        }
    }
#endregion
}
