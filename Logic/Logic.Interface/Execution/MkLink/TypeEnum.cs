namespace XElement.CloudSyncHelper.Logic.Execution.MkLink
{
    public enum Type
    {
        /// <summary>
        /// Corresponds to cmd command "MKLINK link target".
        /// This is the default value.
        /// </summary>
        FILE_LINK = 0, 

        /// <summary>
        /// Corresponds to cmd command "MKLINK /d link target".
        /// </summary>
        DIRECTORY_LINK, 

        /// <summary>
        /// Corresponds to cmd command "MKLINK /h link target".
        /// </summary>
        HARD_LINK, 

        /// <summary>
        /// Corresponds to cmd command "MKLINK /j link target".
        /// </summary>
        DIRECTORY_JUNCTION
    }
}
