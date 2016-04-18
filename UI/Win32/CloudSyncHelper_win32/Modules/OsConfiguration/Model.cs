using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    public class Model
    {
        public Model( IModelParameters @params, 
                      IModelDependencies dependencies )
        {
            this.IsInstalled = @params.IsInstalled;
            this._osChecker = dependencies.OsChecker;
            this._osConfigExecutor = dependencies.OsConfigurationExecutor;
            this._osConfiguration = @params.OsConfiguration;

            this.InitializeCommands();

            this.UpdateCachedProperties();
        }

        private void InitializeCommands()
        {
            this.LinkCommand = new DelegateCommand( this.LinkCommand_Execute, this.LinkCommand_CanExecute );
            this.UnlinkCommand = new DelegateCommand( this.UnlinkCommand_Execute, this.UnlinkCommand_CanExecute );
        }

        private bool IsInCloud { get; set; }

        private bool IsInstalled { get; set; }

        private bool IsLinked { get; set; }

        private bool IsSuitableForOs { get; set; }

        public ICommand LinkCommand { get; private set; }
        private bool LinkCommand_CanExecute()
        {
            return this.IsInstalled && 
                this.IsSuitableForOs && 
                this.IsInCloud && 
                !this.IsLinked;
        }
        private void LinkCommand_Execute()
        {
            this._osConfigExecutor.Link( this._osConfiguration );
            this.UpdateCachedProperties();
            this.RaisePropertiesChanged();
        }

        //  TODO: Copy cloud files to local
        public ICommand UnlinkCommand { get; private set; }
        private bool UnlinkCommand_CanExecute()
        {
            return this.IsLinked;
        }
        private void UnlinkCommand_Execute()
        {
            this._osConfigExecutor.Unlink( this._osConfiguration );
            this.UpdateCachedProperties();
            this.RaisePropertiesChanged();
        }

        private void UpdateCachedProperties()
        {
            this.IsInCloud = this._osConfigExecutor.IsInCloud( this._osConfiguration );
            this.IsLinked = this._osConfigExecutor.IsLinked( this._osConfiguration );
            this.IsSuitableForOs = this._osChecker.IsSuitableForOs( this._osConfiguration );
        }

        private void RaisePropertiesChanged()
        {
            (this.LinkCommand as DelegateCommand).RaiseCanExecuteChanged();
            (this.UnlinkCommand as DelegateCommand).RaiseCanExecuteChanged();
        }

        private IOsChecker _osChecker;
        private IOsConfigurationExecutor _osConfigExecutor;
        private IOsConfiguration _osConfiguration;
    }
#endregion
}
