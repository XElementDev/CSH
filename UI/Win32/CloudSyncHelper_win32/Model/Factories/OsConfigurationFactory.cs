using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export( typeof( IFactory<IOsConfiguration, IOsConfigurationParameters> ) )]
    internal class OsConfigurationFactory : IFactory<IOsConfiguration, IOsConfigurationParameters>
    {

        public IOsConfiguration Get( IOsConfigurationParameters osConfigParams )
        {
            var parameters = new OsConfigurationParametersDTO
            {
                ApplicationInfo = osConfigParams.ApplicationInfo, 
                OsConfigurationInfo = osConfigParams.OsConfigurationInfo, 
                PathVariablesDTO = this._pathVariablesDTO
            };
            return this._osConfigurationFactory.Get( parameters );
        }

        [Import]
        private IOsConfigurationFactory _osConfigurationFactory = null;

        [Import]
        private Logic.PathVariablesDTO _pathVariablesDTO = null;
    }
#endregion
}
