using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    [Export( typeof( IFactory<OsConfiguration.Model, IModelParameters> ) )]
    internal class ModelFactory : IFactory<OsConfiguration.Model, IModelParameters>
    {
        public Model Get( IModelParameters @params )
        {
            var dependencies = new ModelDependencies
            {
                OsChecker = this._osChecker, 
                OsConfigurationFactory = this._osConfigFactory
            };
            var model = new Model( @params, dependencies );
            return model;
        }

        [Import]
        private IOsChecker _osChecker = null;

        [Import]
        private IFactory<Logic.OsConfiguration, IOsConfigurationParameters> _osConfigFactory = null;


        private class ModelDependencies : IModelDependencies
        {
            public IOsChecker OsChecker { get; set; }

            public IFactory<Logic.OsConfiguration, IOsConfigurationParameters> OsConfigurationFactory
            {
                get;
                set;
            }
        }
    }
#endregion
}
