using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Input;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.Common.UI;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    [Export]
    public class MainViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MainViewModel()
        {
            this.SetupProgramViewModelsView();

            this.RefreshCommand = new DelegateCommand( this.RefreshCommand_Execute );
        }

        private ObservableCollection<ProgramViewModel> _programViewModels;
        public ListCollectionView ProgramViewModelsView { get; private set; }

        private bool ProgramViewModelsView_Filter( object obj )
        {
            var programVM = obj as ProgramViewModel;
            return programVM != null && 
                   programVM.DisplayName != null && 
                   programVM.DisplayName != String.Empty;
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

        public ICommand RefreshCommand { get; private set; }
        private void RefreshCommand_Execute()
        {
            RefreshProgramViewModels();
        }


        private void RefreshProgramViewModels()
        {
            this._programViewModels.Clear();
            var installedProgramVMs = this._installedProgramsModel.InstalledProgramVMs;
            var programInfos = this._programInfosModel.ProgramInfos;
            if ( installedProgramVMs.Count > programInfos.Count )
            {
                foreach ( var installedProgram in installedProgramVMs )
                {
                    var programVM = new ProgramViewModel { InstalledProgram = installedProgram };

                    var programInfo = programInfos.SingleOrDefault( pi => 
                        Regex.IsMatch( installedProgram.DisplayName, pi.TechnicalNameMatcher ) );
                    if( programInfo != default(IProgramInfo))
                    {
                        programVM.ProgramInfo = programInfo;
                        programInfos.Remove( programInfo );
                    }

                    this._programViewModels.Add( programVM );
                }

                foreach ( var programInfo in programInfos )
                {
                    var programVM = new ProgramViewModel { ProgramInfo = programInfo };
                    this._programViewModels.Add( programVM );
                }
            }
            else
            {
                // TODO: handling if programInfo list is bigger
                //foreach ( var progamInfo in this._programInfos )
                //{
                //    var programVM = new ProgramViewModel() { ProgramInfo = progamInfo };
                //    this._programViewModels.Add( programVM );
                //}
            }
        }

        private void SetupProgramViewModelsView()
        {
            // TODO: handle empty list entry --> look at the UI
            this._programViewModels = new ObservableCollection<ProgramViewModel>();
            this.ProgramViewModelsView = new ListCollectionView( this._programViewModels );
            var displayNameSorting = new SortDescription( "DisplayName", ListSortDirection.Ascending );
            this.ProgramViewModelsView.SortDescriptions.Add( displayNameSorting );
            this.ProgramViewModelsView.Filter = this.ProgramViewModelsView_Filter;
        }

#pragma warning disable 0649
        [Import]
        private InstalledProgramsModel _installedProgramsModel;

        [Import]
        private ProgramInfosModel _programInfosModel;
#pragma warning restore 0649
    }
#endregion
}
