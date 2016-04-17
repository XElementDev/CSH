using System.Collections.Generic;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    public class Model
    {
        public Model( IModelConstructorParameters ctorParams )
        {
            this.Links = ctorParams.Links;
        }

        public IEnumerable<ILink> Links { get; private set; }
    }
#endregion
}
