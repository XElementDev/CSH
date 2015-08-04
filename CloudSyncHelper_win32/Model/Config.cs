using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;

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

        private Configuration GetConfigFromFile( ConfigurationUserLevel userLevel )
        {
            return ConfigurationManager.OpenMappedExeConfiguration( this.ExeConfigFileMap, userLevel );
        }

        private static string PathToConfig
        {
            get { return Path.Combine( "XElement", "Cloud Sync Helper", "user.config" ); }
        }

        private static string PathToLocalConfig
        {
            get
            {
                var local = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData );
                return Path.Combine( local, PathToConfig );
            }
        }

        private static string PathToRoamingConfig
        {
            get
            {
                var roaming = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData );
                return Path.Combine( roaming, PathToConfig );
            }
        }

        public string /*IConfig.*/PathToSyncFolder { get { return this._local.PathToSyncFolder; } }

        public string /*IConfig.*/UplayAccountName { get { return this._roaming.UplayAccountName; } }

        public string /*IConfig.*/UserName { get { return this._roaming.UserName; } }

        private LocalConfig _local;
        private RoamingConfig _roaming;
    }
#endregion
}
