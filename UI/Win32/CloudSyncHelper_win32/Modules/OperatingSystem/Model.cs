using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OperatingSystem
{
#region not unit-tested
    public class Model
    {
        public Model( IModelConstructorParameters ctorParams )
        {
            this.OsId = ctorParams.OsId;
        }

        public OsId OsId { get; private set; }
    }
#endregion
}
