using System.ComponentModel.Composition;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.Logic.MefExtensions
{
#region not unit-tested
    [Export( typeof( IOsChecker ) )]
    internal class OsChecker : global::XElement.CloudSyncHelper.Logic.OsChecker,
                               IPartImportsSatisfiedNotification
    {
        [ImportingConstructor]
        private OsChecker() : base( null ) { }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this._osRecognizer = this._osRecognizerMef;
        }

        [Import]
        private IOsRecognizer _osRecognizerMef = null;
    }
#endregion
}
