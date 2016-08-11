using System.Reflection;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Server
{
#region not unit-tested
    public class AssemblyInfoAccessor
    {
        public string AssemblyName
        {
            get { return Assembly.GetAssembly( typeof( AssemblyInfoAccessor ) ).GetName().Name; }
        }
    }
#endregion
}
