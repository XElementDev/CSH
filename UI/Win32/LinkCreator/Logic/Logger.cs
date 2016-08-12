using System;
using System.Diagnostics;
using System.Web.Script.Serialization;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Logic
{
#region not unit-tested
    internal static class Logger
    {
        static Logger()
        {
            Logger.InitializeEventLogger();
            Logger._serializer = new JavaScriptSerializer();
        }


        private static void InitializeEventLogger()
        {
            if ( !EventLog.SourceExists( Logger.EVENT_SOURCE ) )
            {
                EventLog.CreateEventSource( Logger.EVENT_SOURCE, Logger.LOG_NAME );
            }

            Logger._eventLog = new EventLog();
            Logger._eventLog.Source = Logger.EVENT_SOURCE;
            Logger._eventLog.Log = Logger.LOG_NAME;
        }


        public static void Log( string logMessage )
        {
            Logger.LogWithTimestamp( logMessage );
        }


        public static string LogRepresentationOf( ParametersDTO parameters )
        {
            var stringRepresentation = Logger._serializer.Serialize( parameters );
            return stringRepresentation;
        }


        private static void LogWithTimestamp( string logMessage )
        {
            var dateTime = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.ffff" );
            var eventLogMessage = $"{dateTime}  Server  {logMessage}";

            Logger._eventLog.WriteEntry( eventLogMessage, EventLogEntryType.Information );
            Console.WriteLine( eventLogMessage );
        }


        private const string EVENT_SOURCE = "LinkCreator";
        private const string LOG_NAME = "Cloud Sync Helper";


        private static EventLog _eventLog;
        private static JavaScriptSerializer _serializer;
    }
#endregion
}
