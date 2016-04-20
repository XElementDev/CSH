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
            var pathVariables = new PathVariables
            {
                PathToSyncFolder = this._config.PathToSyncFolder, 
                UplayUserName = this._config.UplayAccountName, 
                UserName = this._config.UserName
            };
            var parameters = new OsConfigurationParams
            {
                ApplicationInfo = osConfigParams.ApplicationInfo, 
                OsConfigurationInfo = osConfigParams.OsConfigurationInfo, 
                PathVariables = pathVariables
            };
            return this._osConfigurationFactory.Get( parameters );
        }

        [Import]
        IConfig _config = null;

        [Import]
        IOsConfigurationFactory _osConfigurationFactory = null;


        private class OsConfigurationParams : Logic.IOsConfigurationParameters
        {
            public IApplicationInfo ApplicationInfo { get; set; }

            public IOsConfigurationInfo OsConfigurationInfo { get; set; }

            public IPathVariables PathVariables { get; set; }
        }

        private class PathVariables : IPathVariables
        {
            public string PathToSyncFolder { get; set; }

            public string UplayUserName { get; set; }

            public string UserName { get; set; }
        }

    }
#endregion
}
