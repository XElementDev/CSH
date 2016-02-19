using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serializiation;
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
            var currentExecutionPath = ".";
            var uri = Path.Combine( currentExecutionPath, "CloudSyncHelper.xml" );

            var serializationMgr = new SerializationManager( uri );
            var syncData = serializationMgr.Deserialize();
            var programInfoVMs = new List<ProgramInfoViewModel>();
            foreach ( var programInfo in syncData.ApplicationInfos )
            {
                var programInfoVM = this._programInfoVmFactory.Get( programInfo );
                programInfoVMs.Add( programInfoVM );
            }
            this.ProgramInfoVMs = programInfoVMs;
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this.LoadProgramInfos();
        }

        public IEnumerable<ProgramInfoViewModel> ProgramInfoVMs { get; private set; }

        [Import]
        private ProgramInfoViewModelFactory _programInfoVmFactory = null;
    }
#endregion
}
