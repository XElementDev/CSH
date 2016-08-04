using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
using XElement.CloudSyncHelper.Logic.Execution.Link;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    [Export( typeof( IFactory<Model, ModelParametersDTO> ) )]
    internal class ModelFactory : IFactory<Model, ModelParametersDTO>
    {
        public Model Get( ModelParametersDTO @params )
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
        private IFactory<ILink, Win32.Model.LinkParametersDTO> _linkFactory = null;

        [Import]
        private IOsChecker _osChecker = null;

        [Import]
        private IFactory<Logic.IOsConfiguration, Win32.Model.IOsConfigurationParameters> _osConfigFactory = null;
    }
#endregion
}
