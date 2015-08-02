using System;
using System.Collections.Generic;
using System.IO;
using XElement.CloudSyncHelper.DataCreator.Data;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.CloudSyncHelper.Serializiation;

namespace XElement.CloudSyncHelper.DataCreator
{
#region not unit-tested
    class Program
    {
        static void Main( string[] args )
        {
            var desktopPath = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory );
            _filePath = Path.Combine( desktopPath, "CloudSyncHelper.xml" );

            try
            {
                Console.WriteLine( "New data will be stored on your desktop." );
                WriteData();
                Console.WriteLine( String.Format( "All information were successfully written to '{0}'.",
                                                  _filePath ) );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( "An error occurred:" );
                Console.WriteLine( ex.ToString() );
            }
            Console.ReadLine();
        }

        static SyncData CreateData()
        {
            var syncData = new SyncData
            {
                ProgramInfos = new List<AbstractProgramInfo>()
            };
            syncData.ProgramInfos.AddRange( Apps.CreateAppLinkInfos() );
            syncData.ProgramInfos.AddRange( Games.CreateGameLinkInfos() );

            return syncData;
        }

        static void WriteData()
        {
            var sampleData = CreateData();
            new SerializationManager( _filePath ).Serialize( sampleData );
        }

        private static string _filePath = null;
    }
#endregion
}
