using System.Collections.Generic;
using System.Xml.Serialization;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Serialization.DataTypes
{
    public abstract class AbstractProgramInfo : IProgramInfo
    {
        public AbstractProgramInfo()
        {
            this.Configuration = new Configuration();
        }

        [XmlIgnore]
        public Configuration Configuration { get; set; }
        IConfiguration IProgramInfo.Configuration { get { return this.Configuration; } }

        [XmlAttribute( "DisplayName" )]
        public string DisplayName { get; set; }

        [XmlAttribute( "FolderName" )]
        public string FolderName { get; set; }

        [XmlElement( "OS" )]
        public List<OsConfiguration> OsConfigs
        {
            get { return this.Configuration.OsConfigs; }
            set { this.Configuration.OsConfigs = value; }
        }

        [XmlElement( "IsSteamCloudSupported" )]
        public IsSteamCloudSupported SupportsSteamCloud
        {
            get { return new IsSteamCloudSupported { Value = this.Configuration.SupportsSteamCloud }; }
            set { this.SupportsSteamCloud.Value = value.Value; }
        }

        [XmlAttribute( "TechNameMatcher" )]
        public string TechnicalNameMatcher { get; set; }
    }

    public class IsSteamCloudSupported
    {
        [XmlAttribute( "value" )]
        public bool Value { get; set; }
    }
}
