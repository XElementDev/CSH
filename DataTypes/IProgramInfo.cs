namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IProgramInfo
    {
        IConfiguration Configuration { get; }

        string DisplayName { get; }

        string FolderName { get; }

        /// <summary>
        /// A regex that matches the name that is displayed in the installed applications list.
        /// </summary>
        string TechnicalNameMatcher { get; }
    }
}
