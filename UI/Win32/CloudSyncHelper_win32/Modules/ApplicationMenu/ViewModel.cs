using Microsoft.Practices.Prism.Commands;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using AboutViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.About.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu
{
#region not unit-tested
    [Export]
    public class ViewModel
    {
        [ImportingConstructor]
        public ViewModel()
        {
            this.ShowDefault = new DelegateCommand( this.ShowDefault_Execute );
        }

        [Import]
        public AboutViewModel AboutVM { get; private set; }

        public ICommand ShowDefault { get; private set; }

        private void ShowDefault_Execute()
        {
            this._hasWindowState.Value.WindowState = WindowState.@default;
        }

        [Import]
        private Lazy<IHasWindowState> _hasWindowState = null;
    }
#endregion
}
