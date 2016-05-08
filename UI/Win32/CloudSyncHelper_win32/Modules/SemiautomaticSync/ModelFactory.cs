using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
#region not unit-tested
    [Export( typeof( IFactory<Model, IModelParameters> ) )]
    internal class ModelFactory : IFactory<Model, IModelParameters>
    {
        public Model Get( IModelParameters modelParams )
        {
            var dependencies = new ModelDependencies
            {
                DefinitionFactory = this._definitionFactory, 
                OsConfigurationModelFactory = this._osConfigModelFactory
            };
            return new SemiautomaticSync.Model( modelParams, dependencies );
        }

        [Import]
        private IFactory<IDefinition, Win32.Model.DefinitionParametersDTO> _definitionFactory = null;

        [Import]
        private IFactory<OsConfiguration.Model, OsConfiguration.ModelParametersDTO> _osConfigModelFactory = null;


        private class ModelDependencies : IModelDependencies
        {
            public IFactory<IDefinition, Win32.Model.DefinitionParametersDTO> DefinitionFactory
            {
                get;
                set;
            }

            public IFactory<OsConfiguration.Model, OsConfiguration.ModelParametersDTO> OsConfigurationModelFactory
            {
                get;
                set;
            }
        }
    }
#endregion
}
