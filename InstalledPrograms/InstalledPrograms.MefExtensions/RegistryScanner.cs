using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.InstalledPrograms.MefExtensions
{
#region not unit-tested
    [Export( typeof( IScanner ) )]
    public class RegistryScanner : 
        global::XElement.CloudSyncHelper.InstalledPrograms.RegistryScanner { }
#endregion
}
