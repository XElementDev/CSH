using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic;
using XElement.CloudSyncHelper.UI.Win32.Model;

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
            this.InitializePublicProperties( @params );
            this.InitializePrivateProperties( @params, dependencies );
        }

        private void InitializeCommands()
        {
            this.LinkCommand = new DelegateCommand( this.LinkCommand_Execute, this.LinkCommand_CanExecute );
            this.UnlinkCommand = new DelegateCommand( this.UnlinkCommand_Execute, this.UnlinkCommand_CanExecute );
        }

        private void InitializePrivateProperties( IModelParameters @params, IModelDependencies dependencies )
        {
            var factoryParam = new OsConfigurationParameters
            {
                ApplicationInfo = @params.ApplicationInfo,
                OsConfigurationInfo = @params.OsConfigurationInfo
            };
            this._osConfiguration = dependencies.OsConfigurationFactory.Get( factoryParam );

            this._osChecker = dependencies.OsChecker;
            this._osConfigurationInfo = @params.OsConfigurationInfo;
        }

        private void InitializePublicProperties( IModelParameters @params )
        {
            this.IsInstalled = @params.IsInstalled;
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
            this._osConfiguration.Do();
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
            this._osConfiguration.Undo();
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


        private class OsConfigurationParameters : Win32.Model.IOsConfigurationParameters
        {
            public IApplicationInfo ApplicationInfo { get; set; }

            public IOsConfigurationInfo OsConfigurationInfo { get; set; }
        }
    }
#endregion
}
