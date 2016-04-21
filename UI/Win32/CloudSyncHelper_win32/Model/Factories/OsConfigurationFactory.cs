using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.DataTypes;
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
            var parameters = new OsConfigurationParams
            {
                ApplicationInfo = osConfigParams.ApplicationInfo, 
                OsConfigurationInfo = osConfigParams.OsConfigurationInfo, 
                PathVariables = this._pathVariables
            };
            return this._osConfigurationFactory.Get( parameters );
        }

        [Import]
        private IOsConfigurationFactory _osConfigurationFactory = null;

        [Import]
        private IPathVariables _pathVariables = null;


        private class OsConfigurationParams : Logic.IOsConfigurationParameters
        {
            public IApplicationInfo ApplicationInfo { get; set; }

            public IOsConfigurationInfo OsConfigurationInfo { get; set; }

            public IPathVariables PathVariables { get; set; }
        }
    }
#endregion
}
