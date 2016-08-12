using System;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Logic
{
#region not unit-tested
    internal static class Logger
    {
        static Logger() { }


        public static void Log( string logMessage )
        {
            Logger.LogWithTimestamp( logMessage );
        }


        public static string LogRepresentationOf( ParametersDTO parameters )
        {
            var msg = $"link={parameters.Link};target={parameters.Target};type={parameters.Type}";
            return msg;
        }


        private static void LogWithTimestamp( string logMessage )
        {
            var dateTime = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.ffff" );
            Console.Write( $"{dateTime}  " );

            Console.Write( "Server  " );

            Console.WriteLine( logMessage );
        }
    }
#endregion
}
