using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using XElement.CloudSyncHelper.UI.Win32.Model.Configuration;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export( typeof( IConfig ) )]
    public class Config : IConfig
    {
        public Config()
        {
            this.CreateOrLoadLocalConfig();
            this.CreateOrLoadRoamingConfig();
            this.TryCreateRoamingSubFolders();
        }


        private void CreateOrLoadConfig<T>( string sectionKey, 
                                            ref T section, 
                                            Func<T> createNewSection, 
                                            ConfigurationUserLevel userLevel ) where T : ConfigurationSection
        {
            var userSettingsKey = "userSettings";
            var config = this.GetConfigFromFile( userLevel );
            var userSettings = config.SectionGroups.Get( userSettingsKey );

            if ( userSettings == null )
            {
                config.SectionGroups.Add( userSettingsKey, new UserSettingsGroup() );
            }

            section = config.SectionGroups[userSettingsKey].Sections[sectionKey] as T;

            if ( section == null )
            {
                section = createNewSection();
                config.SectionGroups[userSettingsKey].Sections.Add( sectionKey, section );
                config.Save();
            }
        }


        private void CreateOrLoadLocalConfig()
        {
            var userFolderPath = Environment.GetFolderPath( Environment.SpecialFolder.UserProfile );
            Func<LocalConfig> createLocalSection = () => new LocalConfig
            {
                PathToSyncFolder = Path.Combine( userFolderPath, "Google Drive", "SYNC" )
            };
            this.CreateOrLoadConfig<LocalConfig>( "local", ref this._local, createLocalSection, 
                ConfigurationUserLevel.PerUserRoamingAndLocal );
        }


        private void CreateOrLoadRoamingConfig()
        {
            Func<RoamingConfig> createRoamingSection = () => 
                new RoamingConfig { UserName = Environment.UserName };
            this.CreateOrLoadConfig( "roaming", ref this._roaming, createRoamingSection, 
                ConfigurationUserLevel.PerUserRoaming );
        }


        private ExeConfigurationFileMap ExeConfigFileMap
        {
            get
            {
                var exeConfig = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );

                var exeConfigFileMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = exeConfig.FilePath,
                    LocalUserConfigFilename = PathToLocalConfig,
                    RoamingUserConfigFilename = PathToRoamingConfig
                };

                return exeConfigFileMap;
            }
        }


        private System.Configuration.Configuration GetConfigFromFile( ConfigurationUserLevel userLevel )
        {
            return ConfigurationManager.OpenMappedExeConfiguration( this.ExeConfigFileMap, userLevel );
        }


        private static string PathToLocalConfig
        {
            get
            {
                var local = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData );
                return Path.Combine( local, RelativePathToConfigFolder, CONFIG_FILE_NAME );
            }
        }


        /// <summary>
        /// <see cref="IConfig.PathToBannerCache" />
        /// </summary>
        public string PathToBannerCache
        {
            get { return Path.Combine( PathToCache, "banners" ); }
        }


        private static string PathToCache
        {
            get { return Path.Combine( PathToRoamingConfigFolder, "cache" ); }
        }


        /// <summary>
        /// <see cref="IConfig.PathToIconCache" />
        /// </summary>
        public string PathToIconCache
        {
            get { return Path.Combine( PathToCache, "icons" ); }
        }


        /// <summary>
        /// <see cref="IConfig.PathToSyncDataCache" />
        /// </summary>
        public string PathToSyncDataCache { get { return Path.Combine( PathToCache, "syncData" ); } }


        private static string PathToRoamingConfig
        {
            get
            {
                return Path.Combine( PathToRoamingConfigFolder, CONFIG_FILE_NAME );
            }
        }


        private static string PathToRoamingConfigFolder
        {
            get
            {
                var roaming = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData );
                return Path.Combine( roaming, RelativePathToConfigFolder );
            }
        }


        /// <summary>
        /// <see cref="IConfig.PathToSyncFolder" />
        /// </summary>
        public string PathToSyncFolder { get { return this._local.PathToSyncFolder; } }


        private static string RelativePathToConfigFolder
        {
            get { return Path.Combine( "XElement", "Cloud Sync Helper" ); }
        }


        private void TryCreateRoamingSubFolders()
        {
            Directory.CreateDirectory( this.PathToBannerCache );
            Directory.CreateDirectory( this.PathToIconCache );
            Directory.CreateDirectory( this.PathToSyncDataCache );
            return;
        }


        /// <summary>
        /// <see cref="IConfig.UplayAccountName" />
        /// </summary>
        public string UplayAccountName { get { return this._roaming.UplayAccountName; } }


        /// <summary>
        /// <see cref="IConfig.UserName" />
        /// </summary>
        public string UserName { get { return this._roaming.UserName; } }


        private const string CONFIG_FILE_NAME = "user.config";


        private LocalConfig _local;

        private RoamingConfig _roaming;
    }
#endregion
}
