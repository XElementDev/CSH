using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Model.Factories
{
#region not unit-tested
    [Export( typeof( IFactory<IDefinition, DefinitionParametersDTO> ) )]
    internal class DefinitionFactory : IFactory<IDefinition, DefinitionParametersDTO>
    {
        public IDefinition Get( DefinitionParametersDTO parametersDTO )
        {
            var @params = new Logic.DefinitionParametersDTO
            {
                ApplicationInfo = parametersDTO.ApplicationInfo, 
                OsConfigurationInfos = parametersDTO.OsConfigurationInfos, 
                PathVariablesDTO = this._pathVariablesDTO
            };
            return this._definitionFactory.Get( @params );
        }

        [Import]
        private IDefinitionFactory _definitionFactory = null;

        [Import]
        private Logic.PathVariablesDTO _pathVariablesDTO = null;
    }
#endregion
}
