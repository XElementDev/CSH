using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic.Execution;

namespace XElement.CloudSyncHelper.Logic
{
    public class Definition : IDefinition
    {
        public Definition( DefinitionParametersDTO parametersDTO, 
                           DefinitionDependenciesDTO dependenciesDTO )
        {
            this.InitializeUsingParameters( parametersDTO );
            this.InitializeUsingDependencies( dependenciesDTO );
            this.InitializeOsConfigs( parametersDTO.OsConfigurationInfos );
        }


        public IOsConfigurationInfo BestFittingOsConfigurationInfo
        {
            get
            {
                IOsConfigurationInfo bestFittingOsConfigInfo = null;

                var osConfigInfos = this._osConfigurationsMap.Values;
                if ( osConfigInfos.Count != 0 )
                {
                    var filteredOsConfigInfos = this._osFilter
                        .GetFilteredOsConfigs( osConfigInfos );
                    var filteredOsConfigs = this._osConfigurationsMap
                        .Where( kvp => filteredOsConfigInfos.Contains( kvp.Value ) )
                        .Select( kvp => kvp.Key ).ToList();
                    var orderedOsConfigs = filteredOsConfigs
                        .OrderByDescending( o => o.IsLinkedRatio ).ToList();
                    var bestFittingOsConfig = orderedOsConfigs.First();
                    bestFittingOsConfigInfo = this._osConfigurationsMap[bestFittingOsConfig];
                }

                return bestFittingOsConfigInfo;
            }
        }


        private void InitializeOsConfigs( IEnumerable<IOsConfigurationInfo> osConfigurationInfos )
        {
            var osConfigs = new Dictionary<IOsConfigurationInt, IOsConfigurationInfo>();
            foreach ( IOsConfigurationInfo osConfigInfo in osConfigurationInfos )
            {
                var osConfig = this._osConfigurationFactory.Get( this._applicationInfo,
                                                                 osConfigInfo,
                                                                 this._pathVariablesDTO );
                var osConfigInt = osConfig as IOsConfigurationInt;
                osConfigs.Add( osConfigInt, osConfigInfo );
            }
            this._osConfigurationsMap = osConfigs;
        }


        private void InitializeUsingDependencies( DefinitionDependenciesDTO dependenciesDTO )
        {
            this._osConfigurationFactory = dependenciesDTO.OsConfigurationFactory;
            this._osFilter = dependenciesDTO.OsFilter;
        }


        private void InitializeUsingParameters( DefinitionParametersDTO parametersDTO )
        {
            this._applicationInfo = parametersDTO.ApplicationInfo;
            this._pathVariablesDTO = parametersDTO.PathVariablesDTO;
        }


        public bool IsInCloud
        {
            get { return this._osConfigurationsMap.Keys.Any( osCfg => osCfg.IsInCloud ); }
        }


        public bool IsLinked
        {
            get { return this._osConfigurationsMap.Keys.Any( osCfg => osCfg.IsLinked ); }
        }


        private IApplicationInfo _applicationInfo;
        private IOsConfigurationFactory _osConfigurationFactory;
        private IDictionary<IOsConfigurationInt, IOsConfigurationInfo> _osConfigurationsMap;
        private IOsFilter _osFilter;
        private PathVariablesDTO _pathVariablesDTO;
    }
}
