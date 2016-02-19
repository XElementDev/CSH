using System.Xml.Serialization;
using XElement.CloudSyncHelper.DataTypes;
using static System.Environment;

namespace XElement.CloudSyncHelper.Serialization.DataTypes
{
#region not unit-tested
    public abstract class AbstractLinkInfo : ILinkInfo
    {
        [XmlAttribute( "DestRoot" )]
        public SpecialFolder DestinationRoot { get; set; }

        [XmlAttribute( "DestSubFolderPath" )]
        public string DestinationSubFolderPath { get; set; }

        [XmlAttribute( "DestTargetName" )]
        public string DestinationTargetName { get; set; }

        [XmlAttribute( "SourceId" )]
        public string SourceId { get; set; }
    }
#endregion
}
