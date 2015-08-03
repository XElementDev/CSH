using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
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
            this.SetupProgramViewModelsView();

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

        private ObservableCollection<ProgramViewModel> _programViewModels;
        public ListCollectionView ProgramViewModelsView { get; private set; }

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

            RefreshProgramViewModels();
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

        private void RefreshProgramViewModels()
        {
            // TODO: add installed program
            this._programViewModels.Clear();
            foreach ( var progamInfo in this._programInfos )
            {
                var programVM = new ProgramViewModel() { ProgramInfo = progamInfo };
                this._programViewModels.Add( programVM );
            }
        }

        private void SetupProgramViewModelsView()
        {
            this._programViewModels = new ObservableCollection<ProgramViewModel>();
            this.ProgramViewModelsView = new ListCollectionView( this._programViewModels );
            var displayNameSorting = new SortDescription( "DisplayName", ListSortDirection.Ascending );
            this.ProgramViewModelsView.SortDescriptions.Add( displayNameSorting );
        }
    }
#endregion
}
