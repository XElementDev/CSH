using System;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IApplicationInfo
    {
        string ApplicationName { get; }

        IDefinitionInfo DefinitionInfo { get; }

        // TODO: Use guid as folder name
        string FolderName { get; }

        Guid Id { get; }

        // TODO: Extend this: Use also "Herausgeber" field to identify installed application
        /// <summary>
        /// A regex that matches the name that is displayed in the installed applications list.
        /// </summary>
        string TechnicalNameMatcher { get; }

        // TODO: Add publish year for better sorting

        // TODO: Add series name (like "Battlefield") for better sorting (by grouping)
    }
}
