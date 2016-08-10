using System;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Service
{
#region not unit-tested
    internal static class Logger
    {
        static Logger()
        {
            Logger._maxIdLength = 0;
        }


        public static void Log( string id, ParametersDTO parameters )
        {
            var msg = $"link={parameters.Link};target={parameters.Target};type={parameters.Type}";
            Logger.LogWithTimestamp( id, msg );
        }

        public static void Log( string id, string logMessage )
        {
            Logger.LogWithTimestamp( id, logMessage );
        }


        private static void LogWithTimestamp( string id, string logMessage )
        {
            var dateTime = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.ffff" );
            Console.Write( $"{dateTime}  " );

            Logger._maxIdLength = id.Length > Logger._maxIdLength ? id.Length : Logger._maxIdLength;
            Console.Write( $"{id.PadRight( Logger._maxIdLength )}  " );

            Console.WriteLine( logMessage );
        }


        private static int _maxIdLength;
    }
#endregion
}
