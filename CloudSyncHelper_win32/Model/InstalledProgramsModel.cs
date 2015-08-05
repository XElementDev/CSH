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

        public IList<InstalledProgramViewModel> InstalledProgramVMs;

        private void LoadInstalledPrograms()
        {
            this.InstalledProgramVMs.Clear();
            var installedPrograms = new InstalledProgramsHelper().GetInstalledPrograms();
            foreach ( var installedProgram in installedPrograms )
            {
                var installedProgramVM = new InstalledProgramViewModel( installedProgram );
                this.InstalledProgramVMs.Add( installedProgramVM );
            }
        }
    }
#endregion
}
