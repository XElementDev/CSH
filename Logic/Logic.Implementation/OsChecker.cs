using XElement.CloudSyncHelper.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class OsChecker : IOsChecker
    {
        public OsChecker( IOsRecognizer osRecognizer )
        {
            this._osRecognizer = osRecognizer;
        }

        public bool IsSuitableForOs( IOsConfigurationInfo osConfig )
        {
            var runningOsId = this._osRecognizer.GetOsId();
            return runningOsId == osConfig.OsId;
        }

        protected IOsRecognizer _osRecognizer;
    }
#endregion
}
