namespace XElement.CloudSyncHelper.InstalledPrograms
{
    public interface IInstalledProgram
    {
        string DisplayName { get; }
        string InstallLocation { get; }
    }
}
