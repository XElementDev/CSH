using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.InstalledPrograms;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class InstalledProgramsModel : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private InstalledProgramsModel()
        {
            this.InstalledProgramVMs = new List<InstalledProgramViewModel>();
        }

        public IEnumerable<InstalledProgramViewModel> InstalledProgramVMs { get; private set; }

        private void LoadInstalledPrograms()
        {
            var installedProgramVMs = new List<InstalledProgramViewModel>();
            var installedPrograms = this._installedProgramsScanner.GetInstalledPrograms();
            foreach ( var installedProgram in installedPrograms )
            {
                var installedProgramVM = new InstalledProgramViewModel( installedProgram );
                installedProgramVMs.Add( installedProgramVM );
            }
            this.InstalledProgramVMs = installedProgramVMs;
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.LoadInstalledPrograms();
        }

        [Import]
        private IScanner _installedProgramsScanner = null;
    }
#endregion
}
