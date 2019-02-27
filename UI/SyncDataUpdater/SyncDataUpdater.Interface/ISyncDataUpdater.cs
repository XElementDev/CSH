using System.Threading.Tasks;

namespace XElement.CloudSyncHelper.UI.SyncDataUpdater
{
    public interface ISyncDataUpdater
    {
        string LatestSyncDataFilePath { get; }

        string SyncDataFolderPath { get; set; }

        void TryUpdate();

        Task TryUpdateAsync();
    }
}
