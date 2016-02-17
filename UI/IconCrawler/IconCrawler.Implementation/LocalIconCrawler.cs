using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
                this.SelectManyFilePaths();
                this.FilterFilePaths();
                var filePath = this._possibleFilePaths.FirstOrDefault();
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

        private void FilterFilePaths()
        {
            var toRemove = new List<string>();
            foreach ( var filePath in this._possibleFilePaths )
            {
                var blacklist = EXE_NAME_BLACKLIST_REGEX.Union( FOLDER_NAME_BLACKLIST_REGEX ).ToList();
                foreach ( var blacklistEntry in blacklist )
                {
                    if ( Regex.IsMatch( filePath, blacklistEntry, RegexOptions.IgnoreCase ) )
                    {
                        toRemove.Add( filePath );
                    }
                }
            }
            toRemove.ForEach( s => this._possibleFilePaths.Remove( s ) );
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

        private void SelectManyFilePaths()
        {
            var files = Directory.EnumerateFiles( this._input.InstallFolderPath, 
                                                  "*.exe", 
                                                  SearchOption.AllDirectories ).ToList();
            this._possibleFilePaths = files;
        }

        private static IEnumerable<string> EXE_NAME_BLACKLIST_REGEX = new List<string>
        {
            "dotNet.*", 
            ".*install.*", 
            ".*setup.*", 
            "vcredist.*"
        };

        private static IEnumerable<string> FOLDER_NAME_BLACKLIST_REGEX = new List<string>
        {
            "Redist"
        };

        private ICrawlInformation _input;
        private ICollection<string> _possibleFilePaths;
    }
#endregion
}
