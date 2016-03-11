using XElement.CloudSyncHelper.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfigurationAtGlance
{
#region not unit-tested
    public class Model
    {
        public Model( IOsConfiguration osConfig )
        {
            this._osConfig = osConfig;
            this.InitializeOperatingSystemModel();
        }

        public string Author { get { return this._osConfig.Author; } }

        private OperatingSystemModelCtorParams CreateOsModelCtorParams()
        {
            return new OperatingSystemModelCtorParams
            {
                OsId = this._osConfig.OsId
            };
        }

        private void InitializeOperatingSystemModel()
        {
            var ctorParams = new Model.OperatingSystemModelCtorParams
            {
                OsId = this._osConfig.OsId
            };
            this.OperatingSystemModel = new OperatingSystem.Model( ctorParams );
        }

        public string Name { get { return this._osConfig.Name; } }

        public OperatingSystem.Model OperatingSystemModel { get; private set; }

        private IOsConfiguration _osConfig;


        private class OperatingSystemModelCtorParams : OperatingSystem.IModelConstructorParameters
        {
            public OsId OsId { get; set; }
        }
    }
#endregion
}
