using Microsoft.Practices.Prism.Commands;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using AboutViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.About.ViewModel;

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
            this._window.DataContext = this._aboutVM;
            this._window.ShowDialog();
        }

        private Window _window;

        [Import]
        private AboutViewModel _aboutVM = null;
    }
#endregion
}
