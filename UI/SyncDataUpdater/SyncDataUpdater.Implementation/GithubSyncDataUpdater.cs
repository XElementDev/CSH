using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace XElement.CloudSyncHelper.UI.SyncDataUpdater
{
#region not unit-tested
    public class GithubSyncDataUpdater : ISyncDataUpdater
    {
        public GithubSyncDataUpdater()
        {
            var folderName = $"CSH-{Path.GetRandomFileName()}";
            var tempDirectoryFilePath = Path.Combine( Path.GetTempPath(), folderName );
            this.SyncDataFolderPath = tempDirectoryFilePath;

            return;
        }

        static GithubSyncDataUpdater()
        {
            var versionInfo = FileVersionInfo.GetVersionInfo( Assembly.GetEntryAssembly().Location );
            USER_AGENT_NAME = versionInfo.ProductName.Replace( " ", "" );

            SYNC_DATA_FILE_URL = String.Format( URL_FORMAT, OWNER, REPO, PATH );

            return;
        }


        private void CheckForCurrent()
        {
            var dirInfo = new DirectoryInfo( this.SyncDataFolderPath );
            var fileInfos = dirInfo.GetFiles();
            var syncDataFileNames = fileInfos.Select( fi => fi.Name ).ToList();
            this._syncDataFileNames = syncDataFileNames;
            return;
        }


        private async Task CheckForLatestAsync()
        {
            string rawJson = "{}";
            using ( var client = new HttpClient() )
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri( GithubSyncDataUpdater.SYNC_DATA_FILE_URL )
                };
                var customUserAgent = new ProductInfoHeaderValue( GithubSyncDataUpdater.USER_AGENT_NAME, GithubSyncDataUpdater.USER_AGENT_VERSION );
                request.Headers.UserAgent.Add( customUserAgent );
                var response = await client.SendAsync( request );
                rawJson = await response.Content.ReadAsStringAsync();
            }
            var githubBlob = JsonConvert.DeserializeObject<GithubBlob>( rawJson );
            this._githubBlob = githubBlob;
            return;
        }


        private bool IsUpdateAvailable
        {
            get { return !this._syncDataFileNames.Any( fn => fn == this._githubBlob.Sha ); }
        }


        /// <summary>
        /// <see cref="ISyncDataUpdater.LatestSyncDataFilePath" />
        /// </summary>
        public string LatestSyncDataFilePath
        {
            get { return Path.Combine( this.SyncDataFolderPath, this._githubBlob.Sha ); }
        }


        /// <summary>
        /// <see cref="ISyncDataUpdater.SyncDataFolderPath" />
        /// </summary>
        public string SyncDataFolderPath { get; set; }


        /// <summary>
        /// <see cref="ISyncDataUpdater.TryUpdate" />
        /// </summary>
        public void TryUpdate()
        {
            this.TryUpdateAsync().GetAwaiter().GetResult();
            return;
        }

        /// <summary>
        /// <see cref="ISyncDataUpdater.TryUpdateAsync" />
        /// </summary>
        public async Task TryUpdateAsync()
        {
            this.CheckForCurrent();
            await this.CheckForLatestAsync();
            if ( this.IsUpdateAvailable )
            {
                this.Update();
            }

            return;
        }


        private void Update()
        {
            if ( this._githubBlob.Encoding == "base64" )
            {
                var filePath = Path.Combine( this.SyncDataFolderPath, this._githubBlob.Sha );
                var bytes = Convert.FromBase64String( this._githubBlob.Content );
                File.WriteAllBytes( filePath, bytes );
            }
            else
            {
                throw new InvalidOperationException( "This executable can currently only handle base64 content." );
            }
            return;
        }


        private const string OWNER = "XElementDev";

        private const string PATH = "deployment/CloudSyncHelper.xml";

        private const string REPO = "CSH";

        private const string URL_FORMAT = "https://api.github.com/repos/{0}/{1}/contents/{2}";

        private static readonly string USER_AGENT_NAME;

        private const string USER_AGENT_VERSION = "0";

        private static readonly string SYNC_DATA_FILE_URL;


        private GithubBlob _githubBlob;

        private IEnumerable<string> _syncDataFileNames;
    }
#endregion
}
