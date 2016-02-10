using System;
using XElement.CloudSyncHelper.InstalledPrograms;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    public class InstalledProgramViewModel : ViewModelBase
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
