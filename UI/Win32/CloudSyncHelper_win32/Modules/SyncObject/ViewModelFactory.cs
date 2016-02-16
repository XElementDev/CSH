using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.Model;
using SyncObjectModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.Model;
using SyncObjectViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    [Export( typeof( IFactory<SyncObjectViewModel, SyncObjectModel> ) )]
    internal class ViewModelFactory : IFactory<SyncObjectViewModel, SyncObjectModel>
    {
        [ImportingConstructor]
        private ViewModelFactory() { }

        public SyncObjectViewModel Get( SyncObjectModel syncObjectModel )
        {
            return new SyncObjectViewModel( syncObjectModel, 
                                            this._bannerRetrieverModel, 
                                            this._iconRetrieverModel );
        }

        [Import]
        private BannerRetrieverModel _bannerRetrieverModel = null;

        [Import]
        private IconRetrieverModel _iconRetrieverModel = null;
    }
#endregion
}
