using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serializiation;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class ProgramInfosModel
    {
        [ImportingConstructor]
        public ProgramInfosModel( ProgramInfoViewModelFactory factory )
        {
            this._programInfoVmFactory = factory;

            this.LoadProgramInfos();
        }

        private void LoadProgramInfos()
        {
            var serializationMgr = new SerializationManager( @"C:\Users\Christian\Desktop\CloudSyncHelper.xml" );
            var syncData = serializationMgr.Deserialize();
            var programInfoVMs = new List<ProgramInfoViewModel>();
            foreach ( var programInfo in syncData.ProgramInfos )
            {
                var programInfoVM = this._programInfoVmFactory.Get( programInfo );
                programInfoVMs.Add( programInfoVM );
            }
            this.ProgramInfoVMs = programInfoVMs;
        }

        public IEnumerable<ProgramInfoViewModel> ProgramInfoVMs;

        private ProgramInfoViewModelFactory _programInfoVmFactory;
    }
#endregion
}
