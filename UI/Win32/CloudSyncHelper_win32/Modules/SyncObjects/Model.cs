using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.Model;
using SyncObjectModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.Model;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects
{
#region not unit-tested
    [Export]
    internal class Model : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private Model() { }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.PrepareSyncObjectModels();
        }

        private void PrepareSyncObjectModels()
        {
            var syncObjectModelList = new List<SyncObjectModel>();
            foreach ( var programInfoVM in this._programInfosModel.ProgramInfoVMs )
            {
                var syncObjectModel = this._syncObjectModelFactory.Get( programInfoVM );
                syncObjectModelList.Add( syncObjectModel );
            }
            this.SyncObjectModels = syncObjectModelList;
        }

        public IEnumerable<SyncObjectModel> SyncObjectModels { get; private set; }

        [Import]
        IFactory<SyncObjectModel, ProgramInfoViewModel> _syncObjectModelFactory = null;

        [Import]
        private ProgramInfosModel _programInfosModel = null;
    }
#endregion
}
