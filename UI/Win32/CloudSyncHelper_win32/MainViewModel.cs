using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.CloudSyncHelper.UI.Win32.Modules.StatusBar;
using XElement.CloudSyncHelper.UI.Win32.Shortcuts;
using XElement.Common.UI;
using ApplicationMenuViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu.ViewModel;
using MenuBarViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.MenuBar.ViewModel;
using SyncObjectsViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    [Export]
    [Export( typeof( Modules.ApplicationMenu.IApplicationMenuContainer ) )]
    [Export( typeof( Shortcuts.IApplicationMenuContainer ) )]
    [Export( typeof( /*Shortcuts.*/IFilterContainer ) )]
    public class MainViewModel : ViewModelBase, 
                                 Modules.ApplicationMenu.IApplicationMenuContainer, 
                                 Shortcuts.IApplicationMenuContainer,
                                 /*Shortcuts.*/IFilterContainer
    {
        [Import]
        public ApplicationMenuViewModel ApplicationMenuVM { get; private set; }

        void Modules.ApplicationMenu.IApplicationMenuContainer.HideApplicationMenu()
        {
            this.SelectedIndex = 0;
        }

        bool Shortcuts.IApplicationMenuContainer.IsApplicationMenuOpen
        {
            get { return this.SelectedIndex == 1; }
        }

        bool IFilterContainer.IsFilterVisible
        {
            get { return this.MenuBarVM.IsFilterVisible; }
            set { this.MenuBarVM.IsFilterVisible = value; }
        }

        [Import]
        public MenuBarViewModel MenuBarVM { get; private set; }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return this._selectedIndex; }
            set
            {
                this._selectedIndex = value;
                this.RaisePropertyChanged( "SelectedIndex" );
            }
        }

        [Import]
        public ShortcutCommandsViewModel ShortcutCommandsVM { get; private set; }

        void Modules.ApplicationMenu.IApplicationMenuContainer.ShowApplicationMenu()
        {
            this.SelectedIndex = 1;
        }

        [Import]
        public StatusBarViewModel StatusBarVM { get; private set; }

        [Import]
        public SyncObjectsViewModel SyncObjectsVM { get; private set; }

#pragma warning disable CS0414
        //  --> crawling will start on import
        [Import]
        private BannerCrawlerModel _bannerCrawlerModel = null;

        [Import]
        private IconCrawlerModel _iconCrawlerModel = null;
#pragma warning restore CS0414
    }
#endregion
}
