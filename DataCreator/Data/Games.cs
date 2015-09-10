using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        public static List<AbstractProgramInfo> CreateGameLinkInfos()
        {
            return new List<AbstractProgramInfo>
            {
                AgeOfEmpiresIIHD(),
                Anno2070(),
                Pes2015()
            };
        }
    }
}
