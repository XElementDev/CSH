using System;
using System.Collections.Generic;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment;
using UiBannerCrawler = XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Banners;
using UiIconCrawler = XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Icons;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    // TODO: Remove this class.
    public class ProgramInfoViewModel : UiIconCrawler.IIconId, UiBannerCrawler.IObjectToCrawl
    {
        public ProgramInfoViewModel( IApplicationInfo applicationInfo )
        {
            this.ApplicationInfo = applicationInfo;
        }

        internal IApplicationInfo ApplicationInfo { get; private set; }

        string BannerCrawler.ICrawlInformation.ApplicationName { get { return this.DisplayName; } }

        public string DisplayName
        {
            get
            {
                var displayName = String.Empty;
                if ( this.ApplicationInfo != null )
                {
                    displayName = this.ApplicationInfo.ApplicationName;
                }
                return displayName;
            }
        }

        Guid IRetrievalIdContainer.Id /*IBannerId. / IIconId.*/
        {
            get { return this.ApplicationInfo.Id; }
        }

        public IEnumerable<IOsConfigurationInfo> OsConfigs
        {
            get
            {
                IEnumerable<IOsConfigurationInfo> result = new List<IOsConfigurationInfo>();

                var definition = this.ApplicationInfo.DefinitionInfo;
                if ( definition != default( IDefinitionInfo ) )
                {
                    result = definition.OsConfigs;
                }

                return result;
            }
        }

        public bool SupportsSteamCloud
        {
            get { return this.ApplicationInfo.DefinitionInfo.SupportsSteamCloud; }
        }

        public string TechnicalNameMatcher { get { return this.ApplicationInfo.TechnicalNameMatcher; } }
    }
#endregion
}
