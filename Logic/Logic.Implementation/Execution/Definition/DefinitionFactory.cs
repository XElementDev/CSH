namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class DefinitionFactory : IDefinitionFactory
    {
        public DefinitionFactory( ILinkFactory linkFactory, IOsFilter osFilter )
        {
            this._linkFactory = linkFactory;
            this._osFilter = osFilter;
        }

        public IDefinition Get( DefinitionParametersDTO parametersDTO )
        {
            var dependenciesDTO = new DefinitionDependenciesDTO
            {
                LinkFactory = this._linkFactory, 
                OsConfigurationFactory = this._osConfigurationFactory, 
                OsFilter = this._osFilter,
            };
            return new Definition( parametersDTO, dependenciesDTO );
        }

        protected ILinkFactory _linkFactory;
        protected IOsConfigurationFactory _osConfigurationFactory;
        protected IOsFilter _osFilter;
    }
#endregion
}
