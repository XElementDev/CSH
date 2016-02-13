using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;
using SyncObjectViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    [Export( typeof( IFactory<SyncObjectViewModel, ProgramViewModel> ) )]
    internal class ViewModelFactory : IFactory<SyncObjectViewModel, ProgramViewModel>
    {
        [ImportingConstructor]
        private ViewModelFactory() { }

        public SyncObjectViewModel Get( ProgramViewModel programVM )
        {
            return new SyncObjectViewModel( programVM, this._iconRetrieverModel );
        }

        [Import]
        private IconRetrieverModel _iconRetrieverModel = null;
    }
#endregion
}
