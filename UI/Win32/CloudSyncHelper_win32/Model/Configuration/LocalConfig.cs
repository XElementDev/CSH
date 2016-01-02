using System.Configuration;

namespace XElement.CloudSyncHelper.UI.Win32.Model.Configuration
{
#region not unit-tested
    internal class LocalConfig : ConfigurationSection
    {
        public LocalConfig()
        {
            this.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToLocalUser;
        }

        private const string PATH_TO_SYNC_FOLDER = "PathToSyncFolder";
        [ConfigurationProperty( PATH_TO_SYNC_FOLDER, IsRequired=true )]
        public string PathToSyncFolder
        {
            get { return (string)this[PATH_TO_SYNC_FOLDER]; }
            set { this[PATH_TO_SYNC_FOLDER] = value; }
        }
    }
#endregion
}
