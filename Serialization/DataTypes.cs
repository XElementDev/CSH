﻿using System.Collections.Generic;
using System.Xml.Serialization;
using XElement.CloudSyncHelper.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.Serialization.DataTypes
{
#region not unit-tested
    public class DefinitionInfo : IDefinitionInfo
    {
        [XmlIgnore]
        public List<OsConfigurationInfo> OsConfigs { get; set; }
        IEnumerable<IOsConfigurationInfo> IDefinitionInfo.OsConfigs { get { return this.OsConfigs; } }

        [XmlIgnore]
        public bool SupportsSteamCloud { get; set; }
        bool IDefinitionInfo.SupportsSteamCloud { get { return this.SupportsSteamCloud; } }
    }

    public class FileLinkInfo : AbstractLinkInfo, IFileLinkInfo { }

    public class FolderLinkInfo : AbstractLinkInfo, IFolderLinkInfo { }

    public class GameInfo : AbstractApplicationInfo, IGameInfo { }

    public class OsConfigurationInfo : IOsConfigurationInfo
    {
        [XmlAttribute( "author" )]
        public string Author { get; set; }

        [XmlArray( "Links" )]
        [XmlArrayItem( "FileLink"  , typeof( FileLinkInfo ) ),
         XmlArrayItem( "FolderLink", typeof( FolderLinkInfo ) )]
        public List<AbstractLinkInfo> Links { get; set; }
        IReadOnlyList<ILinkInfo> IOsConfigurationInfo.Links { get { return this.Links; } }

        [XmlAttribute( "name" )]
        public string Name { get; set; }

        [XmlAttribute("os")]
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
