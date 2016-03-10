using System.Collections.Generic;
using XElement.CloudSyncHelper.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
#region not unit-tested
    public class OsConfigurationViewModel
    {
        public OsConfigurationViewModel( IOsConfiguration osConfig )
        {
            this._osConfig = osConfig;
            this.InitializeOperatingSystemVM();
        }

        public string Author { get { return this._osConfig.Author; } }

        private OperatingSystemModelCtorParams CreateOsModelCtorParams()
        {
            return new OperatingSystemModelCtorParams
            {
                OsId = this._osConfig.OsId
            };
        }

        private void InitializeOperatingSystemVM()
        {
            var modelParams = this.CreateOsModelCtorParams();
            var model = new OperatingSystem.Model( modelParams );
            var viewModel = new OperatingSystem.ViewModel( model );
            this.OperatingSystemVM = viewModel;
        }

        public IReadOnlyList<ILinkInfo> Links { get { return this._osConfig.Links; } }

        public string Name { get { return this._osConfig.Name; } }

        public OperatingSystem.ViewModel OperatingSystemVM { get; private set; }

        private IOsConfiguration _osConfig = null;


        private class OperatingSystemModelCtorParams : OperatingSystem.IModelConstructorParameters
        {
            public OsId OsId { get; set; }
        }
    }
#endregion
}
