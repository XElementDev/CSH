using System;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface ILinkInfo
    {
        Environment.SpecialFolder DestinationRoot { get; }

        string DestinationSubFolderPath { get; }

        string DestinationTargetName { get; }

        /// <summary>
        /// Used to distinguish between files or folders that have the same name.
        /// Normally this has the same value as '<see cref="ILinkInfo.DestinationTargetName"/>'.
        /// </summary>
        string SourceId { get; }
    }
}
