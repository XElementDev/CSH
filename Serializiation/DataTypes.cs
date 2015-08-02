using System.Collections.Generic;
using System.Xml.Serialization;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Serialization.DataTypes
{
#region not unit-tested
    public abstract class AbstractLinkInfo : ILinkInfo
    {
        [XmlAttribute( "DestRoot" )]
        public System.Environment.SpecialFolder DestinationRoot { get; set; }

        [XmlAttribute( "DestSubFolderPath" )]
        public string DestinationSubFolderPath { get; set; }

        [XmlAttribute( "DestTargetName" )]
        public string DestinationTargetName { get; set; }

        [XmlAttribute( "SourceId" )]
        public string SourceId { get; set; }
    }

    public abstract class AbstractProgramInfo : IProgramInfo
    {
        [XmlAttribute( "DisplayName" )]
        public string DisplayName { get; set; }

        [XmlAttribute( "FolderName" )]
        public string FolderName { get; set; }

        [XmlElement( "OS" )]
        public List<OsConfiguration> OsConfigs { get; set; }
        IReadOnlyList<IOsConfiguration> IProgramInfo.OsConfigs { get { return this.OsConfigs; } }

        [XmlAttribute( "TechNameMatcher" )]
        public string TechnicalNameMatcher { get; set; }
    }

    public class AppInfo : AbstractProgramInfo, IAppInfo { }

    public class FileLinkInfo : AbstractLinkInfo, IFileLinkInfo { }

    public class FolderLinkInfo : AbstractLinkInfo, IFolderLinkInfo { }

    public class GameInfo : AbstractProgramInfo, IGameInfo { }

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
        [XmlElement( "App" , typeof(AppInfo) ),
         XmlElement( "Game", typeof(GameInfo) )]
        public List<AbstractProgramInfo> ProgramInfos { get; set; }
        IReadOnlyList<IProgramInfo> ISyncData.ProgramInfos { get { return this.ProgramInfos; } }
    }
#endregion
}
