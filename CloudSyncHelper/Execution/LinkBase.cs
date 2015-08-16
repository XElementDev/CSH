using System;
using System.Diagnostics;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper
{
#region not unit-tested
    public abstract class LinkBase : ILink
    {
        public LinkBase( IProgramInfo programInfo, ILinkInfo linkInfo, PathVariablesDTO pathVariables )
        {
            this._linkInfo = linkInfo;
            this._pathVariables = pathVariables;
            this._programInfo = programInfo;
        }

        private void CreatePathToDestinationTarget()
        {
            Directory.CreateDirectory( this.PathToDestinationTarget );
        }

        public void /*ILink.*/Do()
        {
            this.CreatePathToDestinationTarget();

            var mkLink = this.GetCmdCommand();
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c " + mkLink;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Verb = "runas";
            process.Start();

            process.WaitForExit();

            // TODO: Handle error if file already exists
            var error = process.StandardError.ReadToEnd();
            var output = process.StandardOutput.ReadToEnd();

            this.StandardOutput = process.StandardOutput.ReadToEnd();
        }

        private string GetAppsOrGamesFolder
        {
            get { return this._programInfo is IAppInfo ? "APPs" 
                                                       : Path.Combine( "GAMEs", "PC", "SAVEs" ); }
        }

        private string GetCmdCommand()
        {
            return String.Format( "MKLINK {0} \"{1}\" \"{2}\"", this._mkLinkParams, this.Link, this.Target );
        }

        public string /*ILink.*/Link
        {
            get
            {
                var link = Path.Combine( this.PathToDestinationTarget, 
                                         this._linkInfo.DestinationTargetName );
                return link;
            }
        }

        private string PathToDestinationTarget
        {
            get
            {
                var destinationRootPath = Environment.GetFolderPath(this._linkInfo.DestinationRoot);
                return Path.Combine( destinationRootPath, this._linkInfo.DestinationSubFolderPath );
            }
        }

        public string /*ILink.*/StandardOutput { get; private set; }

        public string /*ILink.*/Target
        {
            get
            {
                var userFolderName = "-" + this._pathVariables.UserName;
                var target = Path.Combine( this._pathVariables.PathToSyncFolder,
                                           this.GetAppsOrGamesFolder, 
                                           this._programInfo.FolderName, 
                                           userFolderName, this._linkInfo.SourceId );
                return target;
            }
        }

        public void /*ILink.*/Undo()
        {
            // TODO: Delete folders if they are empty
            // TODO: Check for FolderLink logic
            File.Delete( this.Link );
        }

        private ILinkInfo _linkInfo;
        protected abstract string _mkLinkParams { get; }
        private PathVariablesDTO _pathVariables;
        private IProgramInfo _programInfo;
    }
#endregion
}
