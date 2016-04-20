namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class OsConfigurationFactory : IOsConfigurationFactory
    {
        public OsConfigurationFactory( ILinkFactory linkFactory )
        {
            this._linkFactory = linkFactory;
        }

        public IOsConfiguration Get( IOsConfigurationParameters parameters )
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
