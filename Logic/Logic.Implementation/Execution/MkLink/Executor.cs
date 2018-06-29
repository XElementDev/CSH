using System;
using System.Diagnostics;
using System.Security.AccessControl;
using XElement.DotNet.System.Environment.UserInformation;

namespace XElement.CloudSyncHelper.Logic.Execution.MkLink
{
#region not unit-tested
    public class Executor : IExecutor
    {
        public Executor( ParametersDTO parameters, DependenciesDTO dependencies )
        {
            this._link = parameters.Link;
            this._target = parameters.Target;
            this._type = parameters.Type;

            this._roleInformation = dependencies.RoleInfoRetriever.Get();

            return;
        }


        public void /*IExecutor.*/Execute()
        {
#endregion
            if ( this._roleInformation.Role != Role.Administrator )
            {
                throw new PrivilegeNotHeldException( "Admin rights" ); // TODO: Is that the right exception type?
            }
#region not unit-tested
            else
            {
                this.ExecuteCmd();
            }

            return;
        }


        private void ExecuteCmd()
        {
            var mkLink = this.GetCmdCommand();
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c " + mkLink;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Verb = "runas";
            process.Start();

            process.WaitForExit();

            return;
        }


        private string GetCmdCommand()
        {
            return String.Format
            (
                "MKLINK {0} \"{1}\" \"{2}\"", 
                this.TypeAsString, 
                this._link, 
                this._link
            );
        }


        private string TypeAsString
        {
            get
            {
                if      ( this._type == Type.DIRECTORY_LINK )       return "/d";
                else if ( this._type == Type.HARD_LINK )            return "/h";
                else if ( this._type == Type.DIRECTORY_JUNCTION )   return "/j";
                else /*if ( this._type == Type.DEFAULT ) */         return String.Empty;
            }
        }


        private string _link;

        private string _target;

        private Type _type;

        private IRoleInformation _roleInformation;
    }
#endregion
}
