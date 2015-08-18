using System;
using System.Diagnostics;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Execution
{
#region not unit-tested
    internal abstract class LinkBase : ILink
    {
        public LinkBase( IProgramInfo programInfo, ILinkInfo linkInfo, PathVariablesDTO pathVariables )
        {
            this._linkInfo = linkInfo;
            this._pathVariables = pathVariables;
            this._symLinkHelper = new SymbolicLinkHelper();

            Initialize( programInfo );
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

        private bool DoesSymbolicLinkPointToExpectedPath
        {
            get
            {
                var symLinkTarget = this._symLinkHelper.GetSymbolicLinkTarget( this.Link );
                return symLinkTarget == this.Target;
            }
        }

        protected abstract FileSystemInfo FileSystemInfo { get; }

        private string GetCmdCommand()
        {
            return String.Format( "MKLINK {0} \"{1}\" \"{2}\"", this.MkLinkParams, this.Link, this.Target );
        }

        private void Initialize( IProgramInfo programInfo )
        {
            if ( programInfo is IAppInfo )
            {
                this._programLogic = new AppLogic( programInfo );
            }
            else
            {
                this._programLogic = new GameLogic( programInfo );
            }
        }

        public abstract bool /*ILink.*/IsInCloud { get; }

        public bool /*ILink.*/IsLinked
        {
            get
            {
                return this.IsSymbolicLink && 
                    this.DoesSymbolicLinkPointToExpectedPath;
            }
        }

        private bool IsSymbolicLink
        {
            get
            {
                var attr = this.FileSystemInfo.Attributes;
                return this._symLinkHelper.IsSymbolicLink( attr );
            }
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

        protected abstract string MkLinkParams { get; }

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
                                           this._programLogic.PathToUserFolderContainer, 
                                           userFolderName, this._linkInfo.SourceId );
                return target;
            }
        }

        public abstract void /*ILink.*/Undo(); // TODO: Delete folders if they are empty

        private ILinkInfo _linkInfo;
        private PathVariablesDTO _pathVariables;
        private IProgramLogic _programLogic;
        private SymbolicLinkHelper _symLinkHelper;
    }
#endregion
}
