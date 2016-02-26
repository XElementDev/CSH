using System.Collections.Generic;
using System.Xml.Serialization;
using XElement.CloudSyncHelper.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.Serialization.DataTypes
{
#region not unit-tested
    public class Definition : IDefinition
    {
        [XmlIgnore]
        public List<Configuration> Configurations { get; set; }
        IEnumerable<IConfiguration> IDefinition.Configurations
        {
            get { return this.Configurations; }
        }

        [XmlIgnore]
        public bool SupportsSteamCloud { get; set; }
        bool IDefinition.SupportsSteamCloud { get { return this.SupportsSteamCloud; } }
    }

    public class FileLinkInfo : AbstractLinkInfo, IFileLinkInfo { }

    public class FolderLinkInfo : AbstractLinkInfo, IFolderLinkInfo { }

    public class GameInfo : AbstractApplicationInfo, IGameInfo { }

    public class OsConfiguration : IOsConfiguration
    {
        [XmlArray( "Links" )]
        [XmlArrayItem( "FileLink"  , typeof( FileLinkInfo ) ),
         XmlArrayItem( "FolderLink", typeof( FolderLinkInfo ) )]
        public List<AbstractLinkInfo> Links { get; set; }
        IReadOnlyList<ILinkInfo> IOsConfiguration.Links { get { return this.Links; } }

        [XmlAttribute("id")]
        public OsId OsId { get; set; }
    }

    [XmlRoot( "SyncData" )]
    public class SyncData : ISyncData
    {
        [XmlElement( "Game", typeof(GameInfo) ), 
         XmlElement( "Tool" , typeof(ToolInfo) )]
        public List<AbstractApplicationInfo> ApplicationInfos { get; set; }
        IReadOnlyList<IApplicationInfo> ISyncData.ApplicationInfos { get { return this.ApplicationInfos; } }
    }

    public class ToolInfo : AbstractApplicationInfo, IToolInfo { }
#endregion
}
