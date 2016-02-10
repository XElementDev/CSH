using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu;
using XElement.CloudSyncHelper.UI.Win32.Modules.StatusBar;
using XElement.Common.UI;
using ApplicationMenuViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu.ViewModel;
using MenuBarViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.MenuBar.ViewModel;
using SyncObjectsViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    [Export]
    [Export( typeof( IApplicationMenuContainer ) )]
    public class MainViewModel : ViewModelBase, IApplicationMenuContainer
    {
        [Import]
        public ApplicationMenuViewModel ApplicationMenuVM { get; private set; }

        void IApplicationMenuContainer.HideApplicationMenu()
        {
            this.SelectedIndex = 0;
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

        void IApplicationMenuContainer.ShowApplicationMenu()
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
#pragma warning restore CS0414
    }
#endregion
}
