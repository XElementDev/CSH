using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Serializiation;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    internal class ProgramInfosModel
    {
        [ImportingConstructor]
        public ProgramInfosModel()
        {
            this.ProgramInfos = new List<IProgramInfo>();

            this.LoadProgramInfos();
        }

        private void LoadProgramInfos()
        {
            var serializationMgr = new SerializationManager( @"C:\Users\Christian\Desktop\CloudSyncHelper.xml" );
            var syncData = serializationMgr.Deserialize();
            this.ProgramInfos.Clear();
            foreach ( var programInfo in syncData.ProgramInfos )
            {
                this.ProgramInfos.Add( programInfo );
            }
        }

        public IList<IProgramInfo> ProgramInfos;
    }
#endregion
}
