using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Logic.Execution.Link;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.Logic.MefExtensions.Execution.Link
{
#region not unit-tested
    [Export( typeof( ILinkFactory ) )]
    internal class LinkFactory : 
        global::XElement.CloudSyncHelper.Logic.Execution.Link.LinkFactory, 
        IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private LinkFactory() : base( null ) { }


        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this._mkLinkExecutorFactory = this._mkLinkExecutorFactoryMef;
        }


        [Import]
        private IFactory _mkLinkExecutorFactoryMef = null;
    }
#endregion
}
