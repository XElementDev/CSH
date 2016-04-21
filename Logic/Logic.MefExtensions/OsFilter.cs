using System.ComponentModel.Composition;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.Logic.MefExtensions
{
#region not unit-tested
    [Export( typeof( IOsFilter ) )]
    internal class OsFilter : global::XElement.CloudSyncHelper.Logic.OsFilter, 
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
