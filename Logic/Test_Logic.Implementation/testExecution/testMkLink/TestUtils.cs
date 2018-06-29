using System;
using System.IO;
using XeRandom = XElement.TestUtils.Random;

// ↓    TODO: Move to TestUtils project
namespace XElement.CloudSyncHelper.Logic.Execution.MkLink
{
    internal class TempCreateFile : IDisposable
    {
        public TempCreateFile( string fileName )
        {
            this.FileName = fileName;
            this.FilePath = Path.Combine( Path.GetTempPath(), this.FileName );

            this.Create();

            return;
        }

        public TempCreateFile() : this( XeRandom.RandomString() )
        {
            return;
        }


        private void Create()
        {
            using ( var writer = File.CreateText( this.FilePath ) )
            {
                writer.WriteLine( XeRandom.RandomString() );
            }
            return;
        }


        public void /*IDisposable.*/Dispose()
        {
            File.Delete( this.FilePath );
            return;
        }


        public string FileName { get; private set; }


        public string FilePath { get; private set; }

    }


    internal class TempCreateFolder : IDisposable
    {
        public TempCreateFolder( string folderName )
        {
            this.FolderName = folderName;
            this.FolderPath = Path.Combine( Path.GetTempPath(), this.FolderName );

            this.Create();

            return;
        }

        public TempCreateFolder(): this( XeRandom.RandomString() )
        {
            return;
        }


        private void Create()
        {
            Directory.CreateDirectory( this.FolderPath );
            return;
        }


        public void /*IDisposable.*/Dispose()
        {
            Directory.Delete( this.FolderPath );
            return;
        }


        public string FolderName { get; private set; }


        public string FolderPath { get; private set; }
    }
}
