using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Reflection;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.About
{
#region not unit-tested
    [Export]
    public class ViewModel : IPartImportsSatisfiedNotification
    {
        public string Copyright { get; private set; }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.SetAssemblyInfos();
            return;
        }


        public string ProductName { get; private set; }


        private void SetAssemblyInfos()
        {
            // 2016-01-03: https://stackoverflow.com/questions/19384193/get-company-name-and-copyright-information-of-assembly
            var versionInfo = FileVersionInfo.GetVersionInfo( Assembly.GetEntryAssembly().Location );
            this.Copyright = versionInfo.LegalCopyright;
            this.ProductName = versionInfo.ProductName;

            var assemblyVersion = typeof( App ).Assembly.GetName().Version;
            var semVer = $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";
            this.Version = string.Format( "v{0}", semVer );
            return;
        }


        public string Version { get; private set; }
    }
#endregion
}
