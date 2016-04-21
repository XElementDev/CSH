using System;
using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class Definition : IDefinition
    {
        public Definition( DefinitionParametersDTO parametersDTO, 
                           DefinitionDependenciesDTO dependenciesDTO )
        {
            this._applicationInfo = parametersDTO.ApplicationInfo;
            this._linkFactory = dependenciesDTO.LinkFactory;
            this._osConfigurationInfos = parametersDTO.OsConfigurationInfos;
            this._osFilter = dependenciesDTO.OsFilter;
            this._pathVariables = parametersDTO.PathVariables;
        }

        public IOsConfigurationInfo BestFittingOsConfiguration
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
                                                  this._pathVariables );
                links.Add( link );
            }
            int realizedLinks = links.Count( l => l.IsLinked );

            float rating = realizedLinks / potentialLinks;
            return rating;
        }

        private IApplicationInfo _applicationInfo;
        private ILinkFactory _linkFactory;
        private IEnumerable<IOsConfigurationInfo> _osConfigurationInfos;
        private IOsFilter _osFilter;
        private IPathVariables _pathVariables;
    }
#endregion
}
