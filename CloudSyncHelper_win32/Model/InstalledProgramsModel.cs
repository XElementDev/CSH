using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class InstalledProgramsModel
    {
        [ImportingConstructor]
        public InstalledProgramsModel()
        {
            this.InstalledProgramVMs = new List<InstalledProgramViewModel>();

            this.LoadInstalledPrograms();
        }

        public IEnumerable<InstalledProgramViewModel> InstalledProgramVMs { get; private set; }

        private void LoadInstalledPrograms()
        {
            var installedProgramVMs = new List<InstalledProgramViewModel>();
            var installedPrograms = new InstalledProgramsHelper().GetInstalledPrograms();
            foreach ( var installedProgram in installedPrograms )
            {
                var installedProgramVM = new InstalledProgramViewModel( installedProgram );
                installedProgramVMs.Add( installedProgramVM );
            }
            this.InstalledProgramVMs = installedProgramVMs;
        }
    }
#endregion
}
