using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObject
{
#region not unit-tested
    [Export( typeof( IFactory</*SyncObject.*/ViewModel, /*SyncObject.*/Model> ) )]
    internal class ViewModelFactory : IFactory</*SyncObject.*/ViewModel, /*SyncObject.*/Model>
    {
        [ImportingConstructor]
        private ViewModelFactory() { }

        public /*SyncObject.*/ViewModel Get( /*SyncObject.*/Model syncObjectModel )
        {
            return new /*SyncObject.*/ViewModel( syncObjectModel, 
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
