using System;
using System.Diagnostics;
using System.Web.Script.Serialization;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Logic
{
#region not unit-tested
    internal class Logger
    {
        private Logger()
        {
            this.InitializeEventLogger();
            this._serializer = new JavaScriptSerializer();
        }


        public static Logger Get()
        {
            if ( Logger._singleton == null )
            {
                Logger._singleton = new Logger();
            }
            return Logger._singleton;
        }


        public string GetLogRepresentationOf( ParametersDTO parameters )
        {
            var stringRepresentation = this._serializer.Serialize( parameters );
            return stringRepresentation;
        }


        private void InitializeEventLogger()
        {
            if ( !EventLog.SourceExists( Logger.EVENT_SOURCE ) )
            {
                EventLog.CreateEventSource( Logger.EVENT_SOURCE, Logger.LOG_NAME );
            }

            this._eventLog = new EventLog();
            this._eventLog.Source = Logger.EVENT_SOURCE;
            this._eventLog.Log = Logger.LOG_NAME;
        }


        public void Log( string logMessage )
        {
            this.LogWithTimestamp( logMessage );
        }


        private void LogWithTimestamp( string logMessage )
        {
            var dateTime = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.ffff" );
            var eventLogMessage = $"{dateTime}  Server  {logMessage}";

            this._eventLog.WriteEntry( eventLogMessage, EventLogEntryType.Information );
            Console.WriteLine( eventLogMessage );
        }


        private const string EVENT_SOURCE = "LinkCreator";
        private const string LOG_NAME = "Cloud Sync Helper";


        private EventLog _eventLog;
        private JavaScriptSerializer _serializer;
        private static Logger _singleton;
    }
#endregion
}
