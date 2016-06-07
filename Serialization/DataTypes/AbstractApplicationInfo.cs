using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Serialization.DataTypes
{
#region not unit-tested
    public abstract class AbstractApplicationInfo : IApplicationInfo
    {
        public AbstractApplicationInfo()
        {
            this.DefinitionInfo = new DefinitionInfo();
        }

        [XmlAttribute( "ApplicationName" )]
        public string ApplicationName { get; set; }

        [XmlIgnore]
        public DefinitionInfo DefinitionInfo { get; set; }
        IDefinitionInfo IApplicationInfo.DefinitionInfo { get { return this.DefinitionInfo; } }

        [XmlAttribute( "FolderName" )]
        public string FolderName { get; set; }

        [XmlAttribute( "Id" )]
        public Guid /*IApplicationInfo.*/Id { get; set; }


        [XmlElement( "OsConfig" )]
        public List<OsConfigurationInfo> OsConfigs
        {
            get { return this.DefinitionInfo.OsConfigs; }
            set { this.DefinitionInfo.OsConfigs = value; }
        }

        [XmlElement( "IsSteamCloudSupported" )]
        public IsSteamCloudSupported SupportsSteamCloud
        {
            get { return new IsSteamCloudSupported { Value = this.DefinitionInfo.SupportsSteamCloud }; }
            set { this.DefinitionInfo.SupportsSteamCloud = value.Value; }
        }

        [XmlAttribute( "TechNameMatcher" )]
        public string TechnicalNameMatcher { get; set; }
    }

    public class IsSteamCloudSupported
    {
        [XmlAttribute( "value" )]
        public bool Value { get; set; }
    }
#endregion
}
