using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.About
{
#region not unit-tested
    [Export]
    public class ViewModel : IPartImportsSatisfiedNotification
    {
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var assemblyVersion = typeof( App ).Assembly.GetName().Version;
            this.Version = string.Format( "v{0}", assemblyVersion );
        }

        public string Version { get; private set; }
    }
#endregion
}
