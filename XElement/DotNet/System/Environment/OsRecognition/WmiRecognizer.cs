using System.Linq;
using System.Management;

namespace XElement.DotNet.System.Environment
{
    public class WmiRecognizer : IOsRecognizer
    {
        public OsId? /*IOsRecognizer.*/GetOsId()
        {
            var moSearcher = new ManagementObjectSearcher( "Select * from Win32_OperatingSystem" );
            var moReturn = moSearcher.Get();
            var win32_OsObject = moReturn.OfType<ManagementObject>().FirstOrDefault();
            var versionString = win32_OsObject["Version"].ToString();

            return RecognitionHelper.GetOsIdByString( versionString );
        }
    }
}
