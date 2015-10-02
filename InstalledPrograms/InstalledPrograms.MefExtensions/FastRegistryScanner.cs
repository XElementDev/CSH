using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.InstalledPrograms.MefExtensions
{
#region not unit-tested
    [Export( typeof( IScanner ) )]
    internal class FastRegistryScanner : 
        global::XElement.CloudSyncHelper.InstalledPrograms.FastRegistryScanner { }
#endregion
}
