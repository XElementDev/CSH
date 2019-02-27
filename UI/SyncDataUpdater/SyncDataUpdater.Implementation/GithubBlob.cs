namespace XElement.CloudSyncHelper.UI.SyncDataUpdater
{
#region not unit-tested
    internal class GithubBlob
    {
        private GithubBlob()
        {
            return;
        }


        public string Content { get; set; }


        public string Encoding { get; set; }


        public string Sha { get; set; }


        public int Size { get; set; }


        public string Url { get; set; }
    }
#endregion
}
