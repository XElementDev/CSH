using System;
using System.Diagnostics;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution
{
#region not unit-tested
    internal abstract class LinkBase : ILinkInt
    {
        public LinkBase( IApplicationInfo appInfo, 
                         ILinkInfo linkInfo, 
                         PathVariablesDTO pathVariablesDTO )
        {
            this._linkInfo = linkInfo;
            this._pathVariablesDTO = pathVariablesDTO;
            this._symLinkHelper = new SymbolicLinkHelper();

            Initialize( appInfo );
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
                this._programLogic = new ToolLogic( programInfo );
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
                var userFolderName = "-" + this._pathVariablesDTO.UserName;
                var target = Path.Combine( this._pathVariablesDTO.PathToSyncFolder,
                                           this._programLogic.PathToUserFolderContainer, 
                                           userFolderName, this._linkInfo.SourceId );
                return target;
            }
        }

        public abstract void /*ILink.*/Undo(); // TODO: Delete folders if they are empty

        private ILinkInfo _linkInfo;
        private PathVariablesDTO _pathVariablesDTO;
        private IApplicationLogic _programLogic;
        private SymbolicLinkHelper _symLinkHelper;
    }
#endregion
}
