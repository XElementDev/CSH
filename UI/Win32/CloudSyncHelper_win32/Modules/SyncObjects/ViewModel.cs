using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows.Data;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;
using SyncObjectModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.Model;
using SyncObjectsModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects.Model;
using SyncObjectViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects
{
    [Export]
    public class ViewModel : NotifyPropertyChanged, 
                             INotifyPropertyChanged, 
                             IPartImportsSatisfiedNotification
    {
        public bool HasEntries { get { return this.SyncObjectViewModelsView.Count > 0; } }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
#region not unit-tested
            this.LoadSyncObjectVMs();
            this._filterModel.PropertyChanged += ( s, e ) =>
            {
                this.SyncObjectViewModelsView.Refresh();
            };
#endregion
            this._filterModel.PropertyChanged += ( s, e ) =>
            {
                this.RaisePropertyChanged( nameof( this.HasEntries ) );
            };
        }

        [Import]
        private FilterModel _filterModel = null;


#region not unit-tested
        [ImportingConstructor]
        private ViewModel()
        {
            this._syncObjectVMs = new ObservableCollection<SyncObjectViewModel>();
            this.SetupSyncObjectViewModelsView();
        }


        // TODO: feature to move data to SYNC folder


        private void LoadSyncObjectVMs()
        {
            var syncObjectModels = this._syncObjectsModel?.SyncObjectModels ?? 
                                   new List<SyncObject.Model>();
            foreach ( var syncObjectModel in syncObjectModels )
            {
                var syncObjectVM = this._syncObjectVmFactory.Get( syncObjectModel );
                this._syncObjectVMs.Add( syncObjectVM );
            }
        }

        private void SetupSyncObjectViewModelsView()
        {
            this.SyncObjectViewModelsView = new ListCollectionView( this._syncObjectVMs );
            var displayNameSorting = new SortDescription( "Model.DisplayName", ListSortDirection.Ascending );
            this.SyncObjectViewModelsView.SortDescriptions.Add( displayNameSorting );
            this.SyncObjectViewModelsView.Filter = this.SyncObjectViewModelsView_Filter;
        }

        public ListCollectionView SyncObjectViewModelsView { get; private set; }

        private bool SyncObjectViewModelsView_Filter( object obj )
        {
            var syncObjectVM = obj as SyncObjectViewModel;
            return syncObjectVM != null && 
                   syncObjectVM.Model != null && 
                   syncObjectVM.Model.DisplayName != String.Empty && 
                   !this.UserFilteredForThis( syncObjectVM );
        }

        private bool UserFilteredForThis( SyncObjectViewModel syncObjectVM )
        {
            var displayName = syncObjectVM.Model.DisplayName.ToLower();
            Lazy<string> lazyFilter = new Lazy<string>( () => this._filterModel.Filter.ToLower() );
            return this._filterModel != null &&
                   this._filterModel.Filter != null &&
                   this._filterModel.Filter != String.Empty &&
                   !displayName.Contains( lazyFilter.Value );
        }

        [Import]
        private SyncObjectsModel _syncObjectsModel = null;

        [Import]
        private IFactory<SyncObjectViewModel, SyncObjectModel> _syncObjectVmFactory = null;

        private ObservableCollection<SyncObjectViewModel> _syncObjectVMs;
    }
#endregion
}
