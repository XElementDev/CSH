using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    [Export( typeof( IFactory<Model, IModelParameters> ) )]
    internal class ModelFactory : IFactory<Model, IModelParameters>
    {
        public Model Get( IModelParameters @params )
        {
            var dependencies = new ModelDependenciesDTO
            {
                LinkFactory = this._linkFactory, 
                OsChecker = this._osChecker, 
                OsConfigurationFactory = this._osConfigFactory
            };
            var model = new Model( @params, dependencies );
            return model;
        }

        [Import]
        private IFactory<Logic.ILink, Win32.Model.LinkParametersDTO> _linkFactory = null;

        [Import]
        private IOsChecker _osChecker = null;

        [Import]
        private IFactory<Logic.IOsConfiguration, Win32.Model.IOsConfigurationParameters> _osConfigFactory = null;
    }
#endregion
}
