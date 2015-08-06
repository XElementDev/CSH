using Microsoft.Practices.Prism.Events;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
    [Export]
    internal class ProgramViewModelFactory : IFactory<ProgramViewModel>
    {
        public ProgramViewModel /*IFactory<T>.*/Get()
        {
            return new ProgramViewModel( this._eventAggregator, this._config );
        }

#pragma warning disable 0649
        [Import]
        private IConfig _config;

        [Import]
        private IEventAggregator _eventAggregator;
#pragma warning restore 0649
    }
}
