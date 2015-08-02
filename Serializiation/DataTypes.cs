using System.Collections.Generic;
using System.Xml.Serialization;

namespace XElement.CloudSyncHelper.Serialization.DataTypes
{
    public abstract class AbstractLinkInfo
    {
        [XmlAttribute( "DestRoot" )]
        public System.Environment.SpecialFolder DestinationRoot { get; set; }

        [XmlAttribute( "DestSubFolderPath" )]
        public string DestinationSubFolderPath { get; set; }

        [XmlAttribute( "DestTargetName" )]
        public string DestinationTargetName { get; set; }

        /// <summary>
        /// Used to distinguish between files or folders that have the same name.
        /// Normally this has the same value as '<see cref="AbstractLinkInfo.DestinationTargetName"/>'.
        /// </summary>
        [XmlAttribute( "SourceId" )]
        public string SourceId { get; set; }
    }

    public abstract class AbstractProgramInfo
    {
        [XmlAttribute( "DisplayName" )]
        public string DisplayName { get; set; }

        [XmlAttribute( "FolderName" )]
        public string FolderName { get; set; }

        [XmlElement( "OS" )]
        public List<OsConfiguration> OsConfigs { get; set; }
    }

    public class AppInformation : AbstractProgramInfo { }

    public class FileLinkInfo : AbstractLinkInfo { }

    public class FolderLinkInfo : AbstractLinkInfo { }

    public class GameInformation : AbstractProgramInfo { }

    public class OsConfiguration
    {
        [XmlArray( "Links" )]
        [XmlArrayItem( "FileLink"  , typeof( FileLinkInfo ) ),
         XmlArrayItem( "FolderLink", typeof( FolderLinkInfo ) )]
        public List<AbstractLinkInfo> Links { get; set; }

        [XmlAttribute("id")]
        public OsId OsId { get; set; }
    }

    public enum OsId
    {
        WinVista    = 60,
        Win7        = 61,
        Win8        = 62,
        Win81       = 63,
        Win10       = 100
    }

    [XmlRoot( "SyncData" )]
    public class SyncData
    {
        [XmlElement( "App" , typeof(AppInformation) ),
         XmlElement( "Game", typeof(GameInformation) )]
        public List<AbstractProgramInfo> ProgramInfos { get; set; }
    }
}
