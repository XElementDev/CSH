using System.Drawing;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    public class ViewModel : NotifyPropertyChanged
    {
        public ViewModel( ProgramViewModel programVM,
                          IconRetrieverModel iconRetrieverModel )
        {
            this.ProgramVM = programVM;
            this._iconRetrieverModel = iconRetrieverModel;

            this.RetrieveApplicationIcon();
        }

        private Icon _applicationIcon;
        public Icon ApplicationIcon
        {
            get { return this._applicationIcon; }
            private set
            {
                this._applicationIcon = value;
                this.RaisePropertyChanged( nameof( this.ApplicationIcon ) );
                this.RaisePropertyChanged( nameof( this.IsAnIconAvailable ) );
            }
        }

        public bool IsAnIconAvailable { get { return this.ApplicationIcon != null; } }

        public ProgramViewModel ProgramVM { get; private set; }

        private void RetrieveApplicationIcon()
        {
            if ( this.ProgramVM.IsInstalled )
            {
                var installLocation = this.ProgramVM.InstalledProgram.InstallLocation;
                var icon = this._iconRetrieverModel.GetIconFromInstallLocation( installLocation );
                this.ApplicationIcon = icon;
            }
        }

        private IconRetrieverModel _iconRetrieverModel;
    }
#endregion
}
