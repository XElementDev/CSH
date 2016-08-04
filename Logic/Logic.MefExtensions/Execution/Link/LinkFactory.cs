using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic.Execution.Link;

namespace XElement.CloudSyncHelper.Logic.MefExtensions.Execution.Link
{
#region not unit-tested
    [Export( typeof( ILinkFactory ) )]
    internal class LinkFactory : 
        global::XElement.CloudSyncHelper.Logic.Execution.Link.LinkFactory
    {
    }
#endregion
}
