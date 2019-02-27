using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serializiation;
using XElement.CloudSyncHelper.UI.SyncDataUpdater;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class ProgramInfosModel : IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private ProgramInfosModel() { }


        private void LoadProgramInfos()
        {
            var updater = new Updater( this._config.PathToSyncDataCache );
            updater.TryUpdate();
            var serializationMgr = new SerializationManager( updater.LatestSyncDataFilePath );
            var syncData = serializationMgr.Deserialize();
            var programInfoVMs = new List<ProgramInfoViewModel>();
            foreach ( var applicationInfo in syncData.ApplicationInfos )
            {
                var programInfoVM = new ProgramInfoViewModel( applicationInfo );
                programInfoVMs.Add( programInfoVM );
            }
            this.ProgramInfoVMs = programInfoVMs;
            return;
        }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.LoadProgramInfos();
        }


        public IEnumerable<ProgramInfoViewModel> ProgramInfoVMs { get; private set; }


        [Import]
        private IConfig _config = null;
    }
#endregion
}
