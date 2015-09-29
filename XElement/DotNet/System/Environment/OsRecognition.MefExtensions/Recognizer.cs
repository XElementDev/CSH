using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace XElement.DotNet.System.Environment.MefExtensions
{
    [Export( typeof( IOsRecognizer ) )]
    public class Recognizer : IOsRecognizer, IPartImportsSatisfiedNotification
    {
        public OsId? /*IOsRecognizer.*/GetOsId()
        {
            return this._mostPreciseRecognizer.GetOsId();
        }

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            var recognizerResultMap = new Dictionary<IOsRecognizer, OsId?>();

            foreach ( IOsRecognizer recognizer in this._recognizers )
            {
                var osId = recognizer.GetOsId();
                recognizerResultMap.Add( recognizer, osId );
            }

            this._mostPreciseRecognizer = recognizerResultMap.OrderByDescending( kvp => kvp.Value ).First().Key;
        }

        private IOsRecognizer _mostPreciseRecognizer;

        [ImportMany( "1DE5805C-F907-4423-8456-C861AE53A4F9", typeof( IOsRecognizer ) )]
        private List<IOsRecognizer> _recognizers = null;
    }
}
