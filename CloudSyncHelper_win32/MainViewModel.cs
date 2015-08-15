using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Data;
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
        public MainViewModel( IEventAggregator eventAggregator )
        {
            this._eventAggregator = eventAggregator;

            this.SetupProgramViewModelsView();
        }

        private ProgramViewModel ComposeProgramVM( ProgramInfoViewModel programInfoVM )
        {
            var programVM = this._programVmFactory.Get();
            programVM.ProgramInfoVM = programInfoVM;

            var installedProgramVM = this._installedProgramsModel.InstalledProgramVMs
                .SingleOrDefault( p => Regex.IsMatch( p.DisplayName, programInfoVM.TechnicalNameMatcher ) );

            programVM.InstalledProgram = installedProgramVM;
            return programVM;
        }

        private void LoadProgramViewModels()
        {
            this._programViewModels.Clear();
            var programInfoVMs = this._programInfosModel.ProgramInfoVMs;

            foreach ( var programInfoVM in programInfoVMs )
            {
                var programVM = this.ComposeProgramVM( programInfoVM );

                this._programViewModels.Add( programVM );
            }
        }

        // TODO: feature to move data to SYNC folder

        public ListCollectionView ProgramViewModelsView { get; private set; }

        private bool ProgramViewModelsView_Filter( object obj )
        {
            var programVM = obj as ProgramViewModel;
            return programVM != null && 
                   programVM.DisplayName != null && 
                   programVM.DisplayName != String.Empty;
        }

        public void OnMefImportsSatisfied()
        {
            this.LoadProgramViewModels();
        }

        private void SetupProgramViewModelsView()
        {
            this._programViewModels = new ObservableCollection<ProgramViewModel>();
            this.ProgramViewModelsView = new ListCollectionView( this._programViewModels );
            var displayNameSorting = new SortDescription( "DisplayName", ListSortDirection.Ascending );
            this.ProgramViewModelsView.SortDescriptions.Add( displayNameSorting );
            this.ProgramViewModelsView.Filter = this.ProgramViewModelsView_Filter;
        }

        private IEventAggregator _eventAggregator;
        private ObservableCollection<ProgramViewModel> _programViewModels;

#pragma warning disable 0649
        [Import]
        private InstalledProgramsModel _installedProgramsModel;

        [Import]
        private ProgramInfosModel _programInfosModel;

        [Import]
        private ProgramViewModelFactory _programVmFactory;
#pragma warning restore 0649
    }
#endregion
}
