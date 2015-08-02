using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using XElement.CloudSyncHelper.DataCreator.Data;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator
{
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

            using ( var fileStream = new FileStream( FILE_PATH, FileMode.Create ) )
            {
                var serializer = new XmlSerializer( typeof( SyncData ) );
                serializer.Serialize( fileStream, sampleData );
            }
        }

        private static string FILE_PATH = @"C:\Users\Christian\Desktop\CloudSyncHelper.xml";
    }
}
