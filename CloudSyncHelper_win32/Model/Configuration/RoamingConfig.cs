using System.Configuration;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    internal class RoamingConfig : ConfigurationSection
    {
        public RoamingConfig()
        {
            this.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToRoamingUser;
        }

        private const string UPLAY_ACCOUNT_NAME = "UplayAccountName";
        [ConfigurationProperty( UPLAY_ACCOUNT_NAME, IsRequired = true )]
        public string UplayAccountName
        {
            get { return (string)this[UPLAY_ACCOUNT_NAME]; }
            set { this[UPLAY_ACCOUNT_NAME] = value; }
        }

        private const string USER_NAME = "UserName";
        [ConfigurationProperty( USER_NAME, IsRequired=true )]
        public string UserName
        {
            get { return (string)this[USER_NAME]; }
            set { this[USER_NAME] = value; }
        }
    }
#endregion
}
