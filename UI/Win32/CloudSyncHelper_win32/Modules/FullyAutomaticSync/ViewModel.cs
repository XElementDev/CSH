using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync
{
#region not unit-tested
    public class ViewModel
    {
        // TODO: Use IProgramInfo
        public ViewModel( ProgramInfoViewModel programInfoVM )
        {
            this.SupportsSteamCloud = programInfoVM.SupportsSteamCloud;
        }

        public bool IsLinked { get { return this.SupportsSteamCloud; } }

        public bool SupportsSteamCloud { get; private set; }
    }
#endregion
}
