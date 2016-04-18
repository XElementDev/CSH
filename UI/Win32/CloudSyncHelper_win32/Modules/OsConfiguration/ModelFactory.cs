using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
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
                OsConfigurationExecutor = this._osConfigExecutor
            };
            var model = new Model( @params, dependencies );
            return model;
        }

        [Import]
        private IOsChecker _osChecker = null;

        [Import]
        private IOsConfiguration _osConfigExecutor = null;


        private class ModelDependencies : IModelDependencies
        {
            public IOsChecker OsChecker { get; set; }

            public IOsConfiguration OsConfigurationExecutor { get; set; }
        }
    }
#endregion
}
