using System;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IApplicationInfo
    {
        string ApplicationName { get; }

        IDefinition Definition { get; }

        string FolderName { get; }

        Guid Id { get; }

        /// <summary>
        /// A regex that matches the name that is displayed in the installed applications list.
        /// </summary>
        string TechnicalNameMatcher { get; }
    }
}
