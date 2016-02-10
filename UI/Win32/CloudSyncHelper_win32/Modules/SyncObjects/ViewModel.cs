using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Data;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;
using SyncObjectViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects
{
    [Export]
    public class ViewModel : NotifyPropertyChanged, 
                             INotifyPropertyChanged, 
                             IPartImportsSatisfiedNotification
    {
        public bool HasEntries { get { return this.ProgramViewModelsView.Count > 0; } }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
#region not unit-tested
            this.LoadProgramViewModels();
            this.LoadSyncObjectVMs();
            this._filterModel.PropertyChanged += ( s, e ) =>
            {
                this.ProgramViewModelsView.Refresh();
            };
#endregion
            this._filterModel.PropertyChanged += ( s, e ) =>
            {
                this.RaisePropertyChanged( nameof( this.HasEntries ) );
            };
        }

        [Import]
        private FilterModel _filterModel = null;

        [Import]
        private InstalledProgramsModel _installedProgramsModel = null;

        [Import]
        private ProgramInfosModel _programInfosModel = null;

        [Import]
        private ProgramViewModelFactory _programVmFactory = null;


#region not unit-tested
        [ImportingConstructor]
        public ViewModel()
        {
            this._programViewModels = new ObservableCollection<ProgramViewModel>();
            this._syncObjectVMs = new ObservableCollection<SyncObjectViewModel>();
            this.SetupProgramViewModelsView();
        }

        private ProgramViewModel ComposeProgramVM( ProgramInfoViewModel programInfoVM )
        {
            var programVM = this._programVmFactory.Get();
            programVM.ProgramInfoVM = programInfoVM;

            var installedProgramVM = this._installedProgramsModel.InstalledProgramVMs
                .FirstOrDefault( p => Regex.IsMatch( p.DisplayName, programInfoVM.TechnicalNameMatcher ) );

            programVM.InstalledProgram = installedProgramVM;
            return programVM;
        }


        // TODO: feature to move data to SYNC folder

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

        private void LoadSyncObjectVMs()
        {
            foreach ( var programVM in this._programViewModels )
            {
                var syncObjectVM = new SyncObjectViewModel( programVM, this._iconRetrieverModel );
                this._syncObjectVMs.Add( syncObjectVM );
            }
        }

        private ObservableCollection<SyncObjectViewModel> _syncObjectVMs;
        public ListCollectionView ProgramViewModelsView { get; private set; }

        private bool ProgramViewModelsView_Filter( object obj )
        {
            var syncObjectVM = obj as SyncObjectViewModel;
            return syncObjectVM != null &&
                   syncObjectVM.ProgramVM.DisplayName != null &&
                   syncObjectVM.ProgramVM.DisplayName != String.Empty &&
                   !this.UserFilteredForThis( syncObjectVM );
        }

        private void SetupProgramViewModelsView()
        {
            this.ProgramViewModelsView = new ListCollectionView( this._syncObjectVMs );
            var displayNameSorting = new SortDescription( "ProgramVM.DisplayName", ListSortDirection.Ascending );
            this.ProgramViewModelsView.SortDescriptions.Add( displayNameSorting );
            this.ProgramViewModelsView.Filter = this.ProgramViewModelsView_Filter;
        }

        private bool UserFilteredForThis( SyncObjectViewModel syncObjectVM )
        {
            var displayName = syncObjectVM.ProgramVM.DisplayName.ToLower();
            Lazy<string> lazyFilter = new Lazy<string>( () => this._filterModel.Filter.ToLower() );
            return this._filterModel != null &&
                   this._filterModel.Filter != null &&
                   this._filterModel.Filter != String.Empty &&
                   !displayName.Contains( lazyFilter.Value );
        }

        [Import]
        private IconRetrieverModel _iconRetrieverModel = null;

        private ObservableCollection<ProgramViewModel> _programViewModels;
    }
#endregion
}
