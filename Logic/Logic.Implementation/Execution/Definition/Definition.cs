using System;
using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public class Definition : IDefinition
    {
        public Definition( DefinitionParametersDTO parametersDTO, 
                           DefinitionDependenciesDTO dependenciesDTO )
        {
            this._applicationInfo = parametersDTO.ApplicationInfo;
            this._linkFactory = dependenciesDTO.LinkFactory;
            this._osConfigurationInfos = parametersDTO.OsConfigurationInfos;
            this._osFilter = dependenciesDTO.OsFilter;
            this._pathVariablesDTO = parametersDTO.PathVariablesDTO;

            this.InitializeLinks();
        }

        public IOsConfigurationInfo BestFittingOsConfigurationInfo
        {
            get
            {
                var osConfigurationInfoToRatingList = 
                    new List<Tuple<IOsConfigurationInfo, float>>();
                var filteredOsConfigInfos = this._osFilter.GetFilteredOsConfigs( this._osConfigurationInfos );
                foreach ( var osConfigInfo in filteredOsConfigInfos )
                {
                    var rating = this.GetRatingFor( osConfigInfo );
                    var item = new Tuple<IOsConfigurationInfo, float>( osConfigInfo, rating );
                    osConfigurationInfoToRatingList.Add( item );
                }

                var orderedList = osConfigurationInfoToRatingList
                    .OrderByDescending( t => t.Item2 ).ToList();
                return orderedList.FirstOrDefault()?.Item1;
            }
        }

        private float GetRatingFor( IOsConfigurationInfo osConfigurationInfo )
        {
            int potentialLinks = osConfigurationInfo.Links.Count;

            var links = new List<ILink>();
            foreach ( var linkInfo in osConfigurationInfo.Links )
            {
                var link = this._linkFactory.Get( this._applicationInfo, 
                                                  linkInfo, 
                                                  this._pathVariablesDTO );
                links.Add( link );
            }
            int realizedLinks = links.Count( l => l.IsLinked );

            float rating = realizedLinks / potentialLinks;
            return rating;
        }

        private void InitializeLinks()
        {
            this._links = new Dictionary<IOsConfigurationInfo, IEnumerable<ILink>>();
            foreach ( var osConfigInfo in this._applicationInfo.DefinitionInfo.OsConfigs )
            {
                var links = new List<ILink>();
                foreach ( var linkInfo in osConfigInfo.Links )
                {
                    var link = this._linkFactory.Get( this._applicationInfo, 
                                                      linkInfo, 
                                                      this._pathVariablesDTO );
                    links.Add( link );
                }
                this._links.Add( osConfigInfo, links );
            }
        }

        public bool IsLinked
        {
            get
            {
                return this._links.Count != 0 && 
                    this._links.Any( kvp => kvp.Value.All( l => l.IsLinked ) );
            }
        }

        private IApplicationInfo _applicationInfo;
        private ILinkFactory _linkFactory;
        private IDictionary<IOsConfigurationInfo, IEnumerable<ILink>> _links;
        private IEnumerable<IOsConfigurationInfo> _osConfigurationInfos;
        private IOsFilter _osFilter;
        private PathVariablesDTO _pathVariablesDTO;
    }
}
