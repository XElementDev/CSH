using System.ComponentModel.Composition;
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
                OsConfigurationModelFactory = this._osConfigModelFactory
            };
            return new SemiautomaticSync.Model( modelParams, dependencies );
        }

        [Import]
        private IFactory<OsConfiguration.Model, OsConfiguration.IModelParameters> _osConfigModelFactory = null;


        private class ModelDependencies : IModelDependencies
        {
            public IFactory<OsConfiguration.Model, OsConfiguration.IModelParameters> OsConfigurationModelFactory
            {
                get;
                set;
            }
        }
    }
#endregion
}
