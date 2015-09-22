using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Apps
    {
        public static List<AbstractProgramInfo> CreateAppLinkInfos()
        {
            return new List<AbstractProgramInfo>
            {
                ExactAudioCopy(),
                Mp3tag(),
                TeamSpeak3(),
                Winamp()
            };
        }
    }
}
