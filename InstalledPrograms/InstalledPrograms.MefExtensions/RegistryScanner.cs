using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.InstalledPrograms.MefExtensions
{
    [Export( typeof( IScanner ) )]
    internal class RegistryScanner : 
        global::XElement.CloudSyncHelper.InstalledPrograms.RegistryScanner { }
}
