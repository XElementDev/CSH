using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.Logic.MefExtensions
{
#region not unit-tested
    [Export( typeof( IOsConfigurationFactory ) ) ]
    internal class OsConfigurationFactory : 
        global::XElement.CloudSyncHelper.Logic.OsConfigurationFactory
    {
    }
#endregion
}
