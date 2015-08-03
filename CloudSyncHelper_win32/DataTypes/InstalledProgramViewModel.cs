using System;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32.DataTypes
{
#region not unit-tested
    public class InstalledProgramViewModel : ViewModelBase
    {
        public InstalledProgramViewModel( InstalledProgram installedProgram )
        {
            this._installedProgram = installedProgram;
        }

        public string DisplayName
        {
            get
            {
                return this._installedProgram.DisplayName ?? String.Empty;
            }
        }

        private InstalledProgram _installedProgram;
    }
#endregion
}
