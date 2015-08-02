using System;
using System.Collections.Generic;
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
            try
            {
                WriteData();
                Console.WriteLine( String.Format( "All information were successfully written to '{0}'.",
                                                  FILE_PATH ) );
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

            return syncData;
        }

        static void WriteData()
        {
            var sampleData = CreateData();
            new SerializationManager( FILE_PATH ).Serialize( sampleData );
        }

        private static string FILE_PATH = @"C:\Users\Christian\Desktop\CloudSyncHelper.xml";
    }
#endregion
}
