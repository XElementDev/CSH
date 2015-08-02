using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.SetupInstalledApplicationsView();

            this.RefreshData();

            var folderLink = new FolderLink();
            folderLink.Do();
            this.Output = folderLink.StandardOutput;
        }

        private ObservableCollection<InstalledApplication> InstalledApplications { get; set; }
        public ListCollectionView InstalledApplicationsView { get; private set; }

        private bool InstalledApplicationsView_Filter( object obj )
        {
            var installedApplication = obj as InstalledApplication;
            return installedApplication != null && 
                   installedApplication.DisplayName != null && 
                   installedApplication.DisplayName != String.Empty;
        }

        private string _output;
        public string Output
        {
            get { return this._output; }

            set
            {
                this._output = value;
                this.RaisePropertyChanged( "Output" );
            }
        }

        private void RefreshData()
        {
            this.InstalledApplications.Clear();
            var rawInstalledApplications = new InstalledApplicationsHelper().GetInstalledApplications();
            foreach ( var rawInstalledApplication in rawInstalledApplications )
            {
                this.InstalledApplications.Add( rawInstalledApplication );
            }
        }

        private void SetupInstalledApplicationsView()
        {
            this.InstalledApplications = new ObservableCollection<InstalledApplication>();
            this.InstalledApplicationsView = new ListCollectionView( this.InstalledApplications );
            var displayNameSorting = new SortDescription( "DisplayName", ListSortDirection.Ascending );
            this.InstalledApplicationsView.Filter = this.InstalledApplicationsView_Filter;
            this.InstalledApplicationsView.SortDescriptions.Add( displayNameSorting );
        }
    }
#endregion
}
