﻿using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Data;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu;
using XElement.CloudSyncHelper.UI.Win32.Modules.StatusBar;
using XElement.Common.UI;
using ApplicationMenuViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu.ViewModel;
using MenuBarViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.MenuBar.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32
{
#region not unit-tested
    [Export]
    [Export( typeof( IHasWindowState ) )]
    public class MainViewModel : ViewModelBase, IHasWindowState, 
                                                IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        public MainViewModel( IEventAggregator eventAggregator )
        {
            this._eventAggregator = eventAggregator;

            this.SetupProgramViewModelsView();
        }

        [Import]
        public ApplicationMenuViewModel ApplicationMenuVM { get; private set; }

        private ProgramViewModel ComposeProgramVM( ProgramInfoViewModel programInfoVM )
        {
            var programVM = this._programVmFactory.Get();
            programVM.ProgramInfoVM = programInfoVM;

            var installedProgramVM = this._installedProgramsModel.InstalledProgramVMs
                .FirstOrDefault( p => Regex.IsMatch( p.DisplayName, programInfoVM.TechnicalNameMatcher ) );

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

        [Import]
        public MenuBarViewModel MenuBarVM { get; private set; }

        public ListCollectionView ProgramViewModelsView { get; private set; }

        private bool ProgramViewModelsView_Filter( object obj )
        {
            var programVM = obj as ProgramViewModel;
            return programVM != null && 
                   programVM.DisplayName != null && 
                   programVM.DisplayName != String.Empty;
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.LoadProgramViewModels();
        }

        public int SelectedIndex
        {
            get
            {
                IHasWindowState hasWindowState = this;
                return (int)hasWindowState.WindowState;
            }
        }

        private void SetupProgramViewModelsView()
        {
            this._programViewModels = new ObservableCollection<ProgramViewModel>();
            this.ProgramViewModelsView = new ListCollectionView( this._programViewModels );
            var displayNameSorting = new SortDescription( "DisplayName", ListSortDirection.Ascending );
            this.ProgramViewModelsView.SortDescriptions.Add( displayNameSorting );
            this.ProgramViewModelsView.Filter = this.ProgramViewModelsView_Filter;
        }

        [Import]
        public StatusBarViewModel StatusBarVM { get; private set; }

        private WindowState _windowState;
        WindowState IHasWindowState.WindowState
        {
            get { return this._windowState; }
            set
            {
                this._windowState = value;
                this.RaisePropertyChanged( "SelectedIndex" );
            }
        }

        private IEventAggregator _eventAggregator;
        private ObservableCollection<ProgramViewModel> _programViewModels;

        [Import]
        private IconCrawlerModel _iconCrawlerModel = null;

        [Import]
        private InstalledProgramsModel _installedProgramsModel = null;

        [Import]
        private ProgramInfosModel _programInfosModel = null;

        [Import]
        private ProgramViewModelFactory _programVmFactory = null;
    }
#endregion
}