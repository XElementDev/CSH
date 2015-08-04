using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using XElement.CloudSyncHelper.UI.Win32.Model.Config;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    public class AppConfig
    {
        public AppConfig()
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
            Func<RoamingConfig> createRoamingSection = () => new RoamingConfig { UserName = Environment.UserName };
            this.CreateOrLoadConfig( "roaming", ref this._roaming, createRoamingSection, 
                ConfigurationUserLevel.PerUserRoaming );
        }

        //private void CreateOrLoadLocalConfig()
        //{
        //    var localConfig = this.GetConfigFromFile( ConfigurationUserLevel.PerUserRoamingAndLocal );
        //    var userSettings = localConfig.SectionGroups.Get( "userSettings" );

        //    if ( userSettings == null )
        //    {
        //        localConfig.SectionGroups.Add( "userSettings", new UserSettingsGroup() );
        //    }

        //    this._local = localConfig.SectionGroups["userSettings"].Sections["local"] as LocalConfig;

        //    if ( this._local == null )
        //    {
        //        var userFolderPath = Environment.GetFolderPath( Environment.SpecialFolder.UserProfile );
        //        this._local = new LocalConfig
        //        {
        //            PathToSyncFolder = Path.Combine( userFolderPath, "Google Drive", "SYNC" )
        //        };

        //        localConfig.SectionGroups["userSettings"].Sections.Add( "local", this._local );

        //        localConfig.Save();
        //    }
        //}

        //private void CreateOrLoadRoamingConfig()
        //{

        //    var roamingConfig = this.GetConfigFromFile( ConfigurationUserLevel.PerUserRoaming );
        //    var userSettings = roamingConfig.SectionGroups.Get( "userSettings" );
        //    if ( userSettings == null )
        //    {
        //        roamingConfig.SectionGroups.Add( "userSettings", new UserSettingsGroup() );
        //    }

        //    this._roaming = roamingConfig.SectionGroups["userSettings"].Sections["roaming"] as RoamingConfig;

        //    if ( this._roaming == null )
        //    {
        //        this._roaming = new RoamingConfig
        //        {
        //            UserName = Environment.UserName
        //        };

        //        roamingConfig.SectionGroups["userSettings"].Sections.Add( "roaming", this._roaming );

        //        roamingConfig.Save();
        //    }
        //}

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
            get
            {
                return Path.Combine( "XElement", "Cloud Sync Helper", "user.config" );
            }
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

        public string PathToSyncFolder { get { return this._local.PathToSyncFolder; } }

        public string UserName { get { return this._roaming.UserName; } }

        private LocalConfig _local;
        private RoamingConfig _roaming;
    }
#endregion
}
