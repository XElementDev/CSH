using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
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
                InitializeMef();
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

        private static void InitializeMef()
        {
            var catalog = new AggregateCatalog();
            var assembly = typeof( Program ).Assembly;
            catalog.Catalogs.Add( new AssemblyCatalog( assembly ));

            var container = new CompositionContainer( catalog );

            _dataManager = new DataManager();
            container.ComposeParts( _dataManager );
        }

        static void WriteData()
        {
            var sampleData = _dataManager.SyncData;
            new SerializationManager( _filePath ).Serialize( sampleData );
        }

        [Import]
        private static DataManager _dataManager;

        private static string _filePath = null;
    }
#endregion
}
