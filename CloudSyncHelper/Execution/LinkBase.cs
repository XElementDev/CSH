using System;
using System.Diagnostics;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Execution
{
#region not unit-tested
    internal abstract class LinkBase : ILinkCSH
    {
        public LinkBase( IApplicationInfo programInfo, ILinkInfo linkInfo, PathVariablesDTO pathVariables )
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
            this.Undo();
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

        private bool DoesSymbolicLinkPointToExpectedPath
        {
            get
            {
                var symLinkTarget = this._symLinkHelper.GetSymbolicLinkTarget( this.LinkPath );
                return symLinkTarget == this.TargetPath;
            }
        }

        protected abstract FileSystemInfo FileSystemInfo { get; }

        private string GetCmdCommand()
        {
            return String.Format( "MKLINK {0} \"{1}\" \"{2}\"", this.MkLinkParams, 
                this.LinkPath, this.TargetPath );
        }

        private void Initialize( IApplicationInfo programInfo )
        {
            if ( programInfo is IToolInfo )
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

        public string /*ILink.*/LinkPath
        {
            get
            {
                var link = Path.Combine( this.PathToDestinationTarget, 
                                         this._linkInfo.DestinationTargetName );
                return link;
            }
        }

        protected abstract string MkLinkParams { get; }

        public abstract void /*ILink.*/MoveToCloud();

        private string PathToDestinationTarget
        {
            get
            {
                var destinationRootPath = Environment.GetFolderPath(this._linkInfo.DestinationRoot);
                return Path.Combine( destinationRootPath, this._linkInfo.DestinationSubFolderPath );
            }
        }

        public string /*ILink.*/TargetPath
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
