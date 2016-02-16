using SyncObjectModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.Model;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync
{
#region not unit-tested
    public class ViewModel
    {
        // TODO: Use IProgramInfo
        public ViewModel( SyncObjectModel syncObjectModel )
        {
            this.SupportsSteamCloud = syncObjectModel.SupportsSteamCloud;
        }

        public bool IsLinked { get { return this.SupportsSteamCloud; } }

        public bool SupportsSteamCloud { get; private set; }
    }
#endregion
}
