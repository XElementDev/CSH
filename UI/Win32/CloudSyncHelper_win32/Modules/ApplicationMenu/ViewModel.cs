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
            this.Hide = new DelegateCommand( this.Hide_Execute );
        }

        [Import]
        public AboutViewModel AboutVM { get; private set; }

        public ICommand Hide { get; private set; }

        private void Hide_Execute()
        {
            var appMenuContainer = this._lazyAppMenuContainer.Value;
            appMenuContainer.HideApplicationMenu();
        }

        [Import]
        private Lazy<IApplicationMenuContainer> _lazyAppMenuContainer = null;
    }
#endregion
}
