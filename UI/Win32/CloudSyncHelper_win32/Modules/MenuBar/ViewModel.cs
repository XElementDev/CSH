using Microsoft.Practices.Prism.Commands;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu;
using FilterViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.Filter.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.MenuBar
{
    [Export]
    public class ViewModel
    {
        [ImportingConstructor]
        private ViewModel()
        {
            this.ShowApplicationMenu = new DelegateCommand( this.ShowApplicationMenu_Execute );
        }

        [Import]
        public FilterViewModel FilterVM { get; private set; }

        private bool _isFilterVisible;
        public bool IsFilterVisible
        {
            get { return this._isFilterVisible; }
            set
            {
                this._isFilterVisible = value;
                if ( !this.IsFilterVisible )
                {
                    this._filterModel.Filter = String.Empty;
                }
            }
        }

        public ICommand ShowApplicationMenu { get; private set; }

        private void ShowApplicationMenu_Execute()
        {
            this._appMenuContainer.ShowApplicationMenu();
        }

        [Import]
        private IApplicationMenuContainer _appMenuContainer = null;

        [Import]
        private FilterModel _filterModel = null;
    }
}
