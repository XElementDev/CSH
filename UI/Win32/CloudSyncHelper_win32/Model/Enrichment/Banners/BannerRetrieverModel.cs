﻿using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment;
using XElement.CloudSyncHelper.UI.Win32.Model.Enrichment.Banners;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    [Export]
    public class BannerRetrieverModel : RetrieverModelBase<IBannerId>, 
                                        IPartImportsSatisfiedNotification
    {
        public string GetPathToBanner( IBannerId bannerId )
        {
            return this.GetPathToImage( bannerId );
        }

        protected override string PathToImageCache
        {
            get { return this._config.PathToBannerCache; }
        }

        [Import]
        private IConfig _config = null;
    }
#endregion
}
