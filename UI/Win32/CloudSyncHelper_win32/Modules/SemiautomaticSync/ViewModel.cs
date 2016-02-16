using SemiautomaticSyncModel = XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync.Model;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( SemiautomaticSyncModel semiautoSyncModel )
        {
            this.Model = semiautoSyncModel;
        }

        public SemiautomaticSyncModel Model { get; private set; }
    }
#endregion
}
