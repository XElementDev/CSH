using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.Logic.MefExtensions
{
#region not unit-tested
    [Export( typeof( IDefinitionFactory ) )]
    internal class DefinitionFactory : global::XElement.CloudSyncHelper.Logic.DefinitionFactory,
                                       IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private DefinitionFactory() : base( null, null ) { }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this._linkFactory = this._linkFactoryMef;
            this._osFilter = this._osFilterMef;
        }

        [Import]
        private ILinkFactory _linkFactoryMef = null;

        [Import]
        private IOsFilter _osFilterMef = null;
    }
#endregion
}
