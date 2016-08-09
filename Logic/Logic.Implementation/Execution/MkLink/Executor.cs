using System;
using System.Diagnostics;

namespace XElement.CloudSyncHelper.Logic.Execution.MkLink
{
#region not unit-tested
    public class Executor : IExecutor
    {
        public Executor( ParametersDTO parameters )
        {
            this._link = parameters.Link;
            this._target = parameters.Target;
            this._type = parameters.Type;
        }


        public void /*IExecutor.*/Execute()
        {
            // TODO: Throw exception if not in admin mode
            this.ExecuteCmd();
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
        }


        private string GetCmdCommand()
        {
            return String.Format( "MKLINK {0} \"{1}\" \"{2}\"", 
                                  this.TypeAsString, 
                                  this._link, 
                                  this._link );
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
    }
#endregion
}
