namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class OsConfigurationFactory : IOsConfigurationFactory
    {
        public OsConfigurationFactory()
        {

        }

        public IOsConfiguration Get( IOsConfigurationParameters parameters )
        {
            var dependencies = new OsConfigurationDependencies
            {
            };
            return new OsConfiguration( parameters, dependencies );
        }


        private class OsConfigurationDependencies : IOsConfigurationDependencies
        {
        }
    }
#endregion
}
