using Microsoft.Practices.Prism.Commands;
using System.ComponentModel.Composition;
using System.Windows.Input;
using XElement.CloudSyncHelper.UI.Win32.Shortcuts;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    [Export]
    public class ShortcutCommandsViewModel
    {
        public ShortcutCommandsViewModel()
        {
            this.Esc = new DelegateCommand( this.Esc_Execute );
            this.ShowFilter = new DelegateCommand( this.ShowFilter_Execute, this.ShowFilter_CanExecute );
        }

        public ICommand Esc { get; private set; }

        private void Esc_Execute()
        {
            if ( this._appMenuContainer.IsApplicationMenuOpen )
            {
                this._appMenuContainer.IsApplicationMenuOpen = false;
            }
            else if ( this._filterContainer.IsFilterVisible )
            {
                this._filterContainer.IsFilterVisible = false;
            }
        }

        public ICommand ShowFilter { get; private set; }

        private bool ShowFilter_CanExecute()
        {
            return !this._appMenuContainer.IsApplicationMenuOpen;
        }

        private void ShowFilter_Execute()
        {
            this._filterContainer.IsFilterVisible = true;
        }

        [Import]
        private IApplicationMenuContainer _appMenuContainer = null;

        [Import]
        private IFilterContainer _filterContainer = null;
    }
#endregion
}
