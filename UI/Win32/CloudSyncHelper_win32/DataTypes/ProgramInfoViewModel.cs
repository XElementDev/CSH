using System;
using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment;
using UiBannerCrawler = XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Banners;
using UiIconCrawler = XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Icons;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    public class ProgramInfoViewModel : UiIconCrawler.IIconId, UiBannerCrawler.IObjectToCrawl
    {
        public ProgramInfoViewModel( IApplicationInfo applicationInfo, 
                                     IConfig config, 
                                     ConfigForOsHelper cfg4OsHelper )
        {
            this._config = config;
            this._configForOsHelper = cfg4OsHelper;
            this._applicationInfo = applicationInfo;

            InitializeExecutionLogic( applicationInfo );
        }

        string BannerCrawler.ICrawlInformation.ApplicationName { get { return this.DisplayName; } }

        public string DisplayName
        {
            get
            {
                var displayName = String.Empty;
                if ( this._applicationInfo != null )
                {
                    displayName = this._applicationInfo.ApplicationName;
                }
                return displayName;
            }
        }

        public ExecutionLogic ExecutionLogic { get; private set; }

        public bool HasSuitableConfig
        {
            get
            {
                return this.ExecutionLogic != null &&
                    this.ExecutionLogic.HasSuitableConfig();
            }
        }

        Guid IRetrievalIdContainer.Id /*IBannerId. / IIconId.*/
        {
            get { return this._applicationInfo.Id; }
        }

        private void InitializeExecutionLogic( IApplicationInfo appInfo )
        {
            var pathVariables = new PathVariablesDTO
            {
                PathToSyncFolder = this._config.PathToSyncFolder,
                UplayUserName = this._config.UplayAccountName,
                UserName = this._config.UserName
            };
            this.ExecutionLogic = new ExecutionLogic( appInfo, pathVariables, this._configForOsHelper );
        }

        public bool IsInCloud { get { return this.ExecutionLogic.IsInCloud; } }

        public bool IsLinked { get { return this.ExecutionLogic.IsLinked; } }

        public IEnumerable<IOsConfiguration> OsConfigs
        {
            get
            {
                IEnumerable<IOsConfiguration> result = new List<IOsConfiguration>();

                var config = this._applicationInfo.Definition.Configurations.FirstOrDefault();
                if ( config != default( IConfiguration ) )
                {
                    result = config.OsConfigs;
                }

                return result;
            }
        }

        public bool SupportsSteamCloud
        {
            get { return this._applicationInfo.Definition.SupportsSteamCloud; }
        }

        public string TechnicalNameMatcher { get { return this._applicationInfo.TechnicalNameMatcher; } }

        private IApplicationInfo _applicationInfo;
        private IConfig _config;
        private ConfigForOsHelper _configForOsHelper;
    }
#endregion
}
