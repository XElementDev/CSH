using XElement.CloudSyncHelper.Logic;
using XElement.CloudSyncHelper.Logic.Execution.Link;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    public class ModelDependenciesDTO
    {
        public IFactory<ILink, Win32.Model.LinkParametersDTO> LinkFactory { get; set; }

        public IOsChecker OsChecker { get; set; }

        public IFactory<Logic.IOsConfiguration, Win32.Model.IOsConfigurationParameters> OsConfigurationFactory
        {
            get;
            set;
        }
    }
#endregion
}
