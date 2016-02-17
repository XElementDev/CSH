using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
#region not unit-tested
    public class LocalIconCrawler : ICrawler
    {
        public LocalIconCrawler() { }

        private Icon Crawl()
        {
            Icon result = null;

            if ( this._input.InstallFolderPath != null && 
                 this._input.InstallFolderPath != String.Empty )
            {
                var filePath = this.GetFilePath();
                if ( filePath != default( string ) )
                {
                    result = this.IconFromFilePath( filePath );
                }
            }

            return result;
        }

        public ICrawlResult CrawlSingle( ICrawlInformation input )
        {
            this._input = input;
            var icon = this.Crawl();
            return new CrawlResult { Icon = icon, Input = this._input };
        }

        private string GetFilePath()
        {
            var files = Directory.EnumerateFiles( this._input.InstallFolderPath, 
                                                  "*.exe", 
                                                  SearchOption.AllDirectories ).ToList();
            return files.FirstOrDefault();
        }

        //  --> Based on: https://stackoverflow.com/questions/2907565/get-a-list-of-installed-programs-with-application-icons
        //  Last visited: 2016-02-09
        private Icon IconFromFilePath( string filePath )
        {
            Icon result = null;
            try
            {
                result = Icon.ExtractAssociatedIcon( filePath );
            }
            catch { }
            return result;
        }

        private ICrawlInformation _input;
    }
#endregion
}
