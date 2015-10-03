using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace XElement.DotNet.System.Environment.MefExtensions
{
    [Export( typeof( IOsRecognizer ) )]
    internal class CacheAllRecognizer : IOsRecognizer, IPartImportsSatisfiedNotification
    {
        public OsId? /*IOsRecognizer.*/GetOsId()
        {
            return this._cachedMostPreciseOsId;
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var osIds = new List<OsId?>();

            foreach ( IOsRecognizer recognizer in this._recognizers )
            {
                osIds.Add( recognizer.GetOsId() );
            }

            this._cachedMostPreciseOsId = osIds.Max();
        }

        private OsId? _cachedMostPreciseOsId;

        [ImportMany( "1DE5805C-F907-4423-8456-C861AE53A4F9", typeof( IOsRecognizer ) )]
        private List<IOsRecognizer> _recognizers = null;
    }
}
