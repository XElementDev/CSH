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
            this.Definition = new Definition();
        }

        [XmlAttribute( "ApplicationName" )]
        public string ApplicationName { get; set; }

        [XmlElement( "Config" )]
        public List<Configuration> Configurations
        {
            get { return this.Definition.Configurations; }
            set { this.Definition.Configurations = value; }
        }

        [XmlIgnore]
        public Definition Definition { get; set; }
        IDefinition IApplicationInfo.Definition { get { return this.Definition; } }

        [XmlAttribute( "FolderName" )]
        public string FolderName { get; set; }

        [XmlAttribute( "Id" )]
        public Guid /*IApplicationInfo.*/Id { get; set; }

        [XmlElement( "IsSteamCloudSupported" )]
        public IsSteamCloudSupported SupportsSteamCloud
        {
            get { return new IsSteamCloudSupported { Value = this.Definition.SupportsSteamCloud }; }
            set { this.Definition.SupportsSteamCloud = value.Value; }
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
