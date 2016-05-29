using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.Logic.MefExtensions
{
#region not unit-tested
    [Export( typeof( IDefinitionFactory ) )]
    internal class DefinitionFactory : global::XElement.CloudSyncHelper.Logic.DefinitionFactory,
                                       IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private DefinitionFactory() : base( null ) { }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this._osConfigurationFactory = this._osConfigurationFactoryMef;
            this._osFilter = this._osFilterMef;
        }

        [Import]
        private IOsConfigurationFactory _osConfigurationFactoryMef = null;

        [Import]
        private IOsFilter _osFilterMef = null;
    }
#endregion
}
