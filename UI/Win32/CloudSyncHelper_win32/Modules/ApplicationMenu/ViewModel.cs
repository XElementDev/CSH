using System.ComponentModel.Composition;
using AboutViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.About.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu
{
#region not unit-tested
    [Export]
    public class ViewModel
    {
        [Import]
        public AboutViewModel AboutVM { get; private set; }
    }
#endregion
}
