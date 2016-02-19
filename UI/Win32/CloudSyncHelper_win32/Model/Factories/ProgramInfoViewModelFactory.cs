using System;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class ProgramInfoViewModelFactory : IFactory<ProgramInfoViewModel>
    {
        [ImportingConstructor]
        public ProgramInfoViewModelFactory() { }

        ProgramInfoViewModel IFactory<ProgramInfoViewModel>.Get()
        {
            throw new NotImplementedException();
        }
        public ProgramInfoViewModel /*IFactory<T>.*/Get( IApplicationInfo programInfo )
        {
            return new ProgramInfoViewModel( programInfo, this._config, this._configForOsHelper );
        }

        [Import]
        private IConfig _config = null;

        [Import]
        private ConfigForOsHelper _configForOsHelper = null;
    }
#endregion
}
