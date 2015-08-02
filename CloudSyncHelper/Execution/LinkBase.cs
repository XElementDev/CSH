using System;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper
{
#region not unit-tested
    public abstract class LinkBase : ILink
    {
        public LinkBase( IProgramInfo programInfo, ILinkInfo linkInfo )
        {
            this._linkInfo = linkInfo;
            this._programInfo = programInfo;
        }

        public void /*ILink.*/Do()
        {
            var mkLink = this.GetCmdCommand();
            //var process = new Process();
            //process.StartInfo.FileName = "cmd.exe";
            //process.StartInfo.Arguments = "/c " + mkLink;
            //process.StartInfo.CreateNoWindow = true;
            //process.StartInfo.RedirectStandardOutput = true;
            //process.StartInfo.UseShellExecute = false;
            //process.Start();

            //this.StandardOutput = process.StandardOutput.ReadToEnd();
            this.StandardOutput = mkLink;
        }

        private string GetCmdCommand()
        {
            return String.Format( "MKLINK {0} \"{1}\" \"{2}\"", this._mkLinkParams, this.GetLink(), this.GetTarget() );
        }

        private string GetLink()
        {
            var destinationRootPath = Environment.GetFolderPath(this._linkInfo.DestinationRoot);
            var link = Path.Combine( destinationRootPath, this._linkInfo.DestinationSubFolderPath, 
                                     this._linkInfo.DestinationTargetName );
            return link;
        }

        private string GetTarget()
        {
            var gDrivePath = @"D:\Users\Christian\Google Drive";
            var userFolderName = "-" + Environment.UserName;
            var target = Path.Combine( gDrivePath, "SYNC", "", this._programInfo.FolderName, "SAVEs",
                                       userFolderName, this._linkInfo.SourceId );
            return target;
        }

        public string /*ILink.*/StandardOutput { get; private set; }

        public void /*ILink.*/Undo()
        {
            throw new NotImplementedException();
        }

        private ILinkInfo _linkInfo;
        protected abstract string _mkLinkParams { get; }
        private IProgramInfo _programInfo;
    }
#endregion
}
