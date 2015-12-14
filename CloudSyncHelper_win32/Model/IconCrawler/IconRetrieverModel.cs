using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using XElement.CloudSyncHelper.UI.Win32.Model.IconCrawler;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    public class IconRetrieverModel
    {
        public string GetPathToIcon( IIconId iconInformation )
        {
            var cachedImageFiles = Directory.EnumerateFiles( this._config.PathToImageCache, 
                                                             "*.*", SearchOption.TopDirectoryOnly );
            var id = iconInformation.Id.ToString();
            var pathToIcon = cachedImageFiles.FirstOrDefault( fileName => {
                var fileNameWoExtension = Path.GetFileNameWithoutExtension( fileName );
                return fileNameWoExtension.ToLower() == id.ToLower();
                });
            return pathToIcon;
        }

        [Import]
        private IConfig _config = null;
    }
#endregion
}
