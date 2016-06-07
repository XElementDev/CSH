using System;
using XElement.CloudSyncHelper.InstalledPrograms;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    public class InstalledProgramViewModel
    {
        public InstalledProgramViewModel( IInstalledProgram installedProgram )
        {
            this._installedProgram = installedProgram;
        }

        public string DisplayName 
        {
            get { return this._installedProgram.DisplayName ?? String.Empty; }
        }

        public string InstallLocation
        {
            get { return this._installedProgram.InstallLocation ?? String.Empty; }
        }

        private IInstalledProgram _installedProgram;
    }
#endregion
}
