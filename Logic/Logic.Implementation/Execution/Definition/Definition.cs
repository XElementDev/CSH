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
            this.InitializeUsingParameters( parametersDTO );
            this.InitializeUsingDependencies( dependenciesDTO );
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


        private void InitializeUsingDependencies( DefinitionDependenciesDTO dependenciesDTO )
        {
            this._linkFactory = dependenciesDTO.LinkFactory;
            this._osConfigurationFactory = dependenciesDTO.OsConfigurationFactory;
            this._osFilter = dependenciesDTO.OsFilter;
        }


        private void InitializeUsingParameters( DefinitionParametersDTO parametersDTO )
        {
            this._applicationInfo = parametersDTO.ApplicationInfo;
            this._osConfigurationInfos = parametersDTO.OsConfigurationInfos;
            this._pathVariablesDTO = parametersDTO.PathVariablesDTO;
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

#region not unit-tested
        public bool IsInCloud
        {
            get
            {
                var osConfigs = new List<IOsConfiguration>();
                foreach ( IOsConfigurationInfo osConfigInfo in this._osConfigurationInfos )
                {
                    var osConfig = this._osConfigurationFactory.Get( this._applicationInfo, 
                                                                     osConfigInfo, 
                                                                     this._pathVariablesDTO );
                    osConfigs.Add( osConfig );
                }
                return osConfigs.Any( osCfg => osCfg.IsInCloud );
            }
        }


        private IOsConfigurationFactory _osConfigurationFactory;
#endregion
    }
}
