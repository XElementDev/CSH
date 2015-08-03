using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
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
            //this.SetupObservableProgramsView();

            this._installedPrograms = new ObservableCollection<InstalledProgram>();
            this._programInfos = new ObservableCollection<IProgramInfo>();

            this.RefreshCommand = new DelegateCommand( this.RefreshCommand_Execute );
            this.RefreshCommand.Execute( null );
        }

        private ObservableCollection<InstalledProgram> _installedPrograms;

        private bool InstalledApplicationsView_Filter( object obj )
        {
            var installedApplication = obj as InstalledProgram;
            return installedApplication != null && 
                   installedApplication.DisplayName != null && 
                   installedApplication.DisplayName != String.Empty;
        }

        //private ObservableCollection<ProgramViewModel> _observablePrograms;
        //public ListCollectionView ObservableProgramsView { get; private set; }

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

        public ICommand RefreshCommand { get; private set; }
        private void RefreshCommand_Execute()
        {
            RefreshInstalledPrograms();
            RefreshProgramInfos();

            //this._observablePrograms.Add( new ProgramViewModel { ProgramInfo = programInfo } );
        }

        private void RefreshInstalledPrograms()
        {
            this._installedPrograms.Clear();
            var rawInstalledApplications = new InstalledProgramsHelper().GetInstalledPrograms();
            foreach ( var installedApplication in rawInstalledApplications )
            {
                this._installedPrograms.Add( installedApplication );
            }
        }

        private void RefreshProgramInfos()
        {
            var serializationMgr = new SerializationManager( @"C:\Users\Christian\Desktop\CloudSyncHelper.xml" );
            var syncData = serializationMgr.Deserialize();
            this._programInfos.Clear();
            foreach ( var programInfo in syncData.ProgramInfos )
            {
                this._programInfos.Add( programInfo );
            }
        }

        //private void SetupObservableProgramsView()
        //{
        //    this._observablePrograms = new ObservableCollection<ProgramViewModel>();
        //    this.ObservableProgramsView = new ListCollectionView( this._observablePrograms );
        //    var displayNameSorting = new SortDescription( "DisplayName", ListSortDirection.Ascending );
        //    this.ObservableProgramsView.SortDescriptions.Add( displayNameSorting );
        //}
    }
#endregion
}
