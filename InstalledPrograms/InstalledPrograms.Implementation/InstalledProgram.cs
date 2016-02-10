namespace XElement.CloudSyncHelper.InstalledPrograms
{
#region not unit-tested
    internal class InstalledProgram : IInstalledProgram
    {
        public string /*IInstalledProgram.*/DisplayName { get; set; }
        public object EstimatedSize { get; set; }
        public string /*IInstalledProgram.*/InstallLocation { get; set; }
    }
#endregion
}
