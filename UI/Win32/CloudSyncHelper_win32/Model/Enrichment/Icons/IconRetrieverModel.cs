using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Icons;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    public class IconRetrieverModel : RetrieverModelBase<IIconId>, IPartImportsSatisfiedNotification
    {
        public string GetPathToIcon( IIconId iconId )
        {
            return this.GetPathToImage( iconId );
        }

        protected override string PathToImageCache { get { return this._config.PathToIconCache; } }

        [Import]
        private IConfig _config = null;
    }
#endregion
}
