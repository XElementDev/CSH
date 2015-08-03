using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Input;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Serializiation;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.SetupProgramViewModelsView();

            this._installedProgramVMs = new ObservableCollection<InstalledProgramViewModel>();
            this._programInfos = new ObservableCollection<IProgramInfo>();

            this.RefreshCommand = new DelegateCommand( this.RefreshCommand_Execute );
            this.RefreshCommand.Execute( null );
        }

        private ObservableCollection<InstalledProgramViewModel> _installedProgramVMs;

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
            this._installedProgramVMs.Clear();
            var installedPrograms = new InstalledProgramsHelper().GetInstalledPrograms();
            foreach ( var installedProgram in installedPrograms )
            {
                var installedProgramVM = new InstalledProgramViewModel( installedProgram );
                this._installedProgramVMs.Add( installedProgramVM );
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
            if ( this._installedProgramVMs.Count > this._programInfos.Count )
            {
                foreach ( var installedProgram in this._installedProgramVMs )
                {
                    var programVM = new ProgramViewModel { InstalledProgram = installedProgram };

                    var programInfo = this._programInfos.SingleOrDefault( pi => 
                        Regex.IsMatch( installedProgram.DisplayName, pi.TechnicalNameMatcher ) );
                    if( programInfo != default(IProgramInfo))
                    {
                        programVM.ProgramInfo = programInfo;
                        this._programInfos.Remove( programInfo );
                    }

                    this._programViewModels.Add( programVM );
                }
            }
            else
            {
                foreach ( var progamInfo in this._programInfos )
                {
                    var programVM = new ProgramViewModel() { ProgramInfo = progamInfo };
                    this._programViewModels.Add( programVM );
                }
            }
        }

        private void SetupProgramViewModelsView()
        {
            // TODO: handle empty list entry --> look at the UI
            this._programViewModels = new ObservableCollection<ProgramViewModel>();
            this.ProgramViewModelsView = new ListCollectionView( this._programViewModels );
            var displayNameSorting = new SortDescription( "DisplayName", ListSortDirection.Ascending );
            this.ProgramViewModelsView.SortDescriptions.Add( displayNameSorting );
        }
    }
#endregion
}
