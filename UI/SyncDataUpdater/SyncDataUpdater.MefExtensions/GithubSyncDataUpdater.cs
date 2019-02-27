using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.SyncDataUpdater.MefExtensions
{
    [Export( typeof( ISyncDataUpdater ) )]
    internal class GithubSyncDataUpdater :
        global::XElement.CloudSyncHelper.UI.SyncDataUpdater.GithubSyncDataUpdater
    { }
}
