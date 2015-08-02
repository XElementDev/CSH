using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Serializiation;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.SetupInstalledApplicationsView();
            this.SetupProgramInfosView();

            this.RefreshData();
        }

        private ObservableCollection<InstalledProgram> _installedApplications;
        public ListCollectionView InstalledApplicationsView { get; private set; }

        private bool InstalledApplicationsView_Filter( object obj )
        {
            var installedApplication = obj as InstalledProgram;
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

        private ObservableCollection<IProgramInfo> _programInfos;
        public ListCollectionView ProgramInfosView { get; private set; }

        private void RefreshData()
        {
            this._installedApplications.Clear();
            var rawInstalledApplications = new InstalledProgramsHelper().GetInstalledApplications();
            foreach ( var installedApplication in rawInstalledApplications )
            {
                this._installedApplications.Add( installedApplication );
            }

            var serializationMgr = new SerializationManager( @"C:\Users\Christian\Desktop\CloudSyncHelper.xml" );
            var syncData = serializationMgr.Deserialize();
            this._programInfos.Clear();
            foreach ( var programInfo in syncData.ProgramInfos )
            {
                this._programInfos.Add( programInfo );
            }
        }

        private void SetupInstalledApplicationsView()
        {
            this._installedApplications = new ObservableCollection<InstalledProgram>();
            this.InstalledApplicationsView = new ListCollectionView( this._installedApplications );
            var displayNameSorting = new SortDescription( "DisplayName", ListSortDirection.Ascending );
            this.InstalledApplicationsView.SortDescriptions.Add( displayNameSorting );
            this.InstalledApplicationsView.Filter = this.InstalledApplicationsView_Filter;
        }

        private void SetupProgramInfosView()
        {
            this._programInfos = new ObservableCollection<IProgramInfo>();
            this.ProgramInfosView = new ListCollectionView( this._programInfos );
            var displayNameSorting = new SortDescription( "DisplayName", ListSortDirection.Ascending );
            this.ProgramInfosView.SortDescriptions.Add( displayNameSorting );
        }
    }
#endregion
}
