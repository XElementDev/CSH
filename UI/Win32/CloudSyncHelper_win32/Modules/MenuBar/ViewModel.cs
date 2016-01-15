using Microsoft.Practices.Prism.Commands;
using System.ComponentModel.Composition;
using System.Windows.Input;
using XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.MenuBar
{
#region not unit-tested
    [Export]
    public class ViewModel
    {
        public ViewModel()
        {
            this.ShowApplicationMenu = new DelegateCommand( this.ShowApplicationMenu_Execute );
        }

        public ICommand ShowApplicationMenu { get; private set; }

        private void ShowApplicationMenu_Execute()
        {
            this._hasWindowState.WindowState = WindowState.ShowApplicationMenu;
        }

        [Import]
        private IHasWindowState _hasWindowState;
    }
#endregion
}
