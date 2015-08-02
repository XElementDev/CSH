using System;
using System.Diagnostics;

namespace XElement.CloudSyncHelper
{
    public abstract class LinkBase : ILink
    {
        public void /*ILink.*/Do()
        {
            var mkLink = String.Format( "MKLINK /? {0}", this._mkLinkParams );
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c " + mkLink;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            this.StandardOutput = process.StandardOutput.ReadToEnd();
        }

        public string /*ILink.*/StandardOutput { get; private set; }

        public void /*ILink.*/Undo()
        {
            throw new NotImplementedException();
        }

        protected abstract string _mkLinkParams { get; }
    }
}
