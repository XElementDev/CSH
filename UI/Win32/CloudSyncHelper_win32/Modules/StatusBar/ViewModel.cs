using System.ComponentModel.Composition;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.StatusBar
{
#region not unit-tested
    [Export]
    public class StatusBarViewModel : IPartImportsSatisfiedNotification
    {
        public bool IsWindows8_1 { get; private set; }

        public bool IsWindows10 { get; private set; }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var osId = this._osRecognizer.GetOsId();

            if ( osId == OsId.Win81 ) this.IsWindows8_1 = true;
            else if ( osId == OsId.Win10 ) this.IsWindows10 = true;
        }

        [Import]
        private IOsRecognizer _osRecognizer = null;
    }
#endregion
}
