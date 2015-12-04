using Microsoft.Practices.Prism.Commands;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.MenuBar
{
#region not unit-tested
    [Export]
    public class ViewModel
    {
        public ViewModel()
        {
            this.ShowAbout = new DelegateCommand( this.ShowAbout_Execute );
        }

        public ICommand ShowAbout { get; private set; }

        private void ShowAbout_Execute()
        {
            this._window = new AboutWindow();
            this._window.ShowDialog();
        }

        private Window _window;
    }
#endregion
}
