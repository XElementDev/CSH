using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.Logic.MefExtensions
{
#region not unit-tested
    [Export( typeof( IOsConfigurationFactory ) )]
    internal class OsConfigurationFactory :
        global::XElement.CloudSyncHelper.Logic.OsConfigurationFactory,
        IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private OsConfigurationFactory() : base( null ) { }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this._linkFactory = this._linkFactoryMef;
        }

        [Import]
        private ILinkFactory _linkFactoryMef = null;
    }
#endregion
}
