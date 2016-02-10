using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.IO;
using System.Linq;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    public class IconRetrieverModel
    {
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

        private string GetFilePath( string installLocation )
        {
            var files = Directory.EnumerateFiles( installLocation, "*.exe" ).ToList();
            return files.FirstOrDefault();
        }

        public Icon GetIconFromInstallLocation( string installLocation )
        {
            Icon icon = null;

            if ( installLocation != String.Empty )
            {
                var filePath = this.GetFilePath( installLocation );
                icon = this.IconFromFilePath( filePath );
            }

            return icon;
        }
    }
#endregion
}
