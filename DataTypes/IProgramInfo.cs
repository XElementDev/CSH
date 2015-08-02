using System.Collections.Generic;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IProgramInfo
    {
        string DisplayName { get; }

        string FolderName { get; }

        IReadOnlyList<IOsConfiguration> OsConfigs { get; }

        /// <summary>
        /// A regex that matches the name that is displayed in the installed applications list.
        /// </summary>
        string TechnicalNameMatcher { get; }
    }
}
