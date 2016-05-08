namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class DefinitionDependenciesDTO
    {
        public ILinkFactory LinkFactory { get; set; }


        public IOsConfigurationFactory OsConfigurationFactory { get; set; }


        public IOsFilter OsFilter { get; set; }
    }
#endregion
}
