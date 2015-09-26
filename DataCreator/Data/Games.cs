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
                Battlefield3(),
                BioshockInfinite(),
                Borderlands2(),
                Evolve(),
                OrcsMustDie2(),
                Pes2015(),
                RocketLeague(),
                Terraria(),
                TokiTori()
            };
        }
    }
}
