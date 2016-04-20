using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export( typeof( IFactory<ILink, LinkParametersDTO> ) )]
    internal class LinkFactory : IFactory<ILink, LinkParametersDTO>
    {
        public ILink Get( LinkParametersDTO linkParametersDTO )
        {
            var pathVariables = new PathVariables
            {
                PathToSyncFolder = this._config.PathToSyncFolder,
                UplayUserName = this._config.UplayAccountName,
                UserName = this._config.UserName
            };
            return this._linkFactory.Get( linkParametersDTO.ApplicationInfo, 
                                          linkParametersDTO.LinkInfo, 
                                          pathVariables );
        }

        [Import]
        IConfig _config = null;

        [Import]
        private ILinkFactory _linkFactory = null;


        private class PathVariables : IPathVariables
        {
            public string PathToSyncFolder { get; set; }

            public string UplayUserName { get; set; }

            public string UserName { get; set; }
        }
    }
#endregion
}
