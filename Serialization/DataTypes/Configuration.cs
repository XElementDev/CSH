using System.Collections.Generic;
using System.Xml.Serialization;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Serialization.DataTypes
{
#region not unit-tested
    public class Configuration : IConfiguration
    {
        [XmlAttribute( "author" )]
        public string Author { get; set; }

        [XmlAttribute( "name" )]
        public string Name { get; set; }

        [XmlElement( "OS" )]
        public List<OsConfiguration> OsConfigs { get; set; }
        IEnumerable<IOsConfiguration> IConfiguration.OsConfigs { get { return this.OsConfigs; } }
    }
#endregion
}
