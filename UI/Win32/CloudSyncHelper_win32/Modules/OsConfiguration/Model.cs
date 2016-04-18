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
            this.Initialize( @params, dependencies );

            this.UpdateCachedProperties();
        }

        private void Initialize( IModelParameters @params, IModelDependencies dependencies )
        {
            this.InitializeCommands();
            this.InitializeComponents( @params, dependencies );

            //this._osConfiguration = new 
        }

        private void InitializeCommands()
        {
            this.LinkCommand = new DelegateCommand( this.LinkCommand_Execute, this.LinkCommand_CanExecute );
            this.UnlinkCommand = new DelegateCommand( this.UnlinkCommand_Execute, this.UnlinkCommand_CanExecute );
        }

        private void InitializeComponents( IModelParameters @params, IModelDependencies dependencies )
        {
            this.IsInstalled = @params.IsInstalled;
            this._osChecker = dependencies.OsChecker;
            this._osConfigurationInfo = @params.OsConfigurationInfo;
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
            this._osConfiguration.Link();
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
            this._osConfiguration.Unlink();
            this.UpdateCachedProperties();
            this.RaisePropertiesChanged();
        }

        private void UpdateCachedProperties()
        {
            this.IsInCloud = this._osConfiguration.IsInCloud;
            this.IsLinked = this._osConfiguration.IsLinked;
            this.IsSuitableForOs = this._osChecker.IsSuitableForOs( this._osConfigurationInfo );
        }

        private void RaisePropertiesChanged()
        {
            (this.LinkCommand as DelegateCommand).RaiseCanExecuteChanged();
            (this.UnlinkCommand as DelegateCommand).RaiseCanExecuteChanged();
        }

        private IOsChecker _osChecker;
        private IOsConfiguration _osConfiguration;
        private IOsConfigurationInfo _osConfigurationInfo;
    }
#endregion
}
