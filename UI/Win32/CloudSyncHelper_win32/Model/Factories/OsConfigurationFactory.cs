using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class OsConfigurationFactory : IFactory<OsConfiguration, IOsConfigurationParameters>
    {

        public OsConfiguration Get( IOsConfigurationParameters osConfigParams )
        {
            var pathVariables = new PathVariables
            {
                PathToSyncFolder = this._config.PathToSyncFolder, 
                UplayUserName = this._config.UplayAccountName, 
                UserName = this._config.UserName
            };
            return new OsConfiguration( osConfigParams.ApplicationInfo, 
                                        osConfigParams.OsConfigurationInfo, 
                                        pathVariables );
        }

        [Import]
        IConfig _config = null;


        private class PathVariables : IPathVariables
        {
            public string PathToSyncFolder { get; set; }

            public string UplayUserName { get; set; }

            public string UserName { get; set; }
        }

    }
#endregion
}
