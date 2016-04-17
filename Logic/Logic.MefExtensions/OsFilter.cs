using System.ComponentModel.Composition;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.MefExtensions
{
#region not unit-tested
    [Export]
    internal class OsFilter : global::XElement.CloudSyncHelper.OsFilter, 
                              IPartImportsSatisfiedNotification
    {
        private OsFilter() : base( null ) { }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            this._osRecognizer = this._osRecognizerMef;
        }

        [Import]
        private IOsRecognizer _osRecognizerMef = null;
    }
#endregion
}
