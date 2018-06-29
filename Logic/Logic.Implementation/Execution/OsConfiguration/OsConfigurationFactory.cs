using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic.Execution.Link;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class OsConfigurationFactory : IOsConfigurationFactory
    {
        public OsConfigurationFactory( ILinkFactory linkFactory )
        {
            this._linkFactory = linkFactory;
        }


        public IOsConfiguration Get( IApplicationInfo appInfo, 
                                     IOsConfigurationInfo osConfigInfo, 
                                     PathVariablesDTO pathVariables )
        {
            var parameters = new OsConfigurationParametersDTO
            {
                ApplicationInfo = appInfo, 
                OsConfigurationInfo = osConfigInfo, 
                PathVariablesDTO = pathVariables
            };
            return this.Get( parameters );
        }

        public IOsConfiguration Get( OsConfigurationParametersDTO parameters )
        {
            var dependencies = new OsConfigurationDependenciesDTO
            {
                LinkFactory = this._linkFactory
            };
            return new OsConfiguration( parameters, dependencies );
        }


        protected ILinkFactory _linkFactory;
    }
#endregion
}
