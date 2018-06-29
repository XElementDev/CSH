using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic.Execution.Link;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export( typeof( IFactory<ILink, LinkParametersDTO> ) )]
    internal class LinkFactory : IFactory<ILink, LinkParametersDTO>
    {
        public ILink Get( LinkParametersDTO linkParametersDTO )
        {
            return this._linkFactory.Get( linkParametersDTO.ApplicationInfo, 
                                          linkParametersDTO.LinkInfo, 
                                          this._pathVariablesDTO );
        }

        [Import]
        private ILinkFactory _linkFactory = null;

        [Import]
        Logic.PathVariablesDTO _pathVariablesDTO = null;
    }
#endregion
}
