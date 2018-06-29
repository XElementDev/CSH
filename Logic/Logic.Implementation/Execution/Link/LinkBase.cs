using System;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution.Link
{
#region not unit-tested
    internal abstract class LinkBase : ILinkInt
    {
        public LinkBase( LinkParametersDTO parametersDTO, 
                         DependenciesDTO dependenciesDTO )
        {
            this._mkLinkExecutorFactory = dependenciesDTO.MkLinkExecutorFactory;

            this._linkInfo = parametersDTO.LinkInfo;
            this._pathVariablesDTO = parametersDTO.PathVariablesDTO;
            this._symLinkHelper = new SymbolicLinkHelper();

            Initialize( parametersDTO.ApplicationInfo );
        }


        private void CreatePathToDestinationTarget()
        {
            Directory.CreateDirectory( this.PathToDestinationTarget );
        }


        public void /*ILink.*/Do()
        {
            this.CreatePathToDestinationTarget();
            this.Undo();

            var mkLinkParams = new MkLink.ParametersDTO
            {
                Link = this.LinkPath, 
                Target = this.TargetPath, 
                Type = this.MkLinkType
            };
            this._mkLinkExecutorFactory.Get( mkLinkParams ).Execute();
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


        protected abstract MkLink.Type MkLinkType { get; }


        public void /*ILink.*/MoveToCloud()
        {
            Directory.CreateDirectory( this.PathToCloudUserFolder );
            this.MoveToCloud_CopyStuff();
        }


        protected abstract void MoveToCloud_CopyStuff();


        private string PathToDestinationTarget
        {
            get
            {
                var destinationRootPath = Environment.GetFolderPath(this._linkInfo.DestinationRoot);
                return Path.Combine( destinationRootPath, this._linkInfo.DestinationSubFolderPath );
            }
        }


        private string PathToCloudUserFolder
        {
            get
            {
                var userFolderName = "-" + this._pathVariablesDTO.UserName;
                var cloudUserFolder = Path.Combine( this._pathVariablesDTO.PathToSyncFolder, 
                                                    this._programLogic.PathToUserFolderContainer, 
                                                    userFolderName );
                return cloudUserFolder;
            }
        }


        public string /*ILink.*/TargetPath
        {
            get
            {
                var target = Path.Combine( this.PathToCloudUserFolder, this._linkInfo.SourceId );
                return target;
            }
        }


        public abstract void /*ILink.*/Undo(); // TODO: Delete folders if they are empty


        private ILinkInfo _linkInfo;
        private MkLink.IFactory _mkLinkExecutorFactory;
        private PathVariablesDTO _pathVariablesDTO;
        private IApplicationLogic _programLogic;
        private SymbolicLinkHelper _symLinkHelper;
    }
#endregion
}
