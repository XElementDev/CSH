using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class OsConfigurationFactory : IFactory<OsConfiguration>
    {

        public OsConfiguration Get()
        {
            var pathVariables = new PathVariables
            {
            };
            return new OsConfiguration( appInfo, osConfigInfo, pathVariables );
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
