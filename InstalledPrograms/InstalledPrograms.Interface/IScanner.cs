using System.Collections.Generic;

namespace XElement.CloudSyncHelper.InstalledPrograms
{
    public interface IScanner
    {
        IEnumerable<IInstalledProgram> GetInstalledPrograms();
    }
}
