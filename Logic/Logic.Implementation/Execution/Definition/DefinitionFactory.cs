namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class DefinitionFactory : IDefinitionFactory
    {
        public DefinitionFactory( IOsFilter osFilter )
        {
            this._osFilter = osFilter;
        }

        public IDefinition Get( DefinitionParametersDTO parametersDTO )
        {
            var dependenciesDTO = new DefinitionDependenciesDTO
            {
                OsConfigurationFactory = this._osConfigurationFactory, 
                OsFilter = this._osFilter,
            };
            return new Definition( parametersDTO, dependenciesDTO );
        }

        protected IOsConfigurationFactory _osConfigurationFactory;
        protected IOsFilter _osFilter;
    }
#endregion
}
