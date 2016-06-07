using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.Logic.MefExtensions.Execution.Link
{
#region not unit-tested
    [Export( typeof( ILinkFactory ) )]
    internal class LinkFactory : global::XElement.CloudSyncHelper.Logic.LinkFactory
    {
    }
#endregion
}
