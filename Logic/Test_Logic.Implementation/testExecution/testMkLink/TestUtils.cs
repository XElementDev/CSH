using System;
using System.IO;
using XeRandom = XElement.TestUtils.Random;

// ↓    TODO: Move to TestUtils project
namespace XElement.CloudSyncHelper.Logic.Execution.MkLink
{
    internal abstract class TempCreateFsItem : IDisposable
    {
        public TempCreateFsItem( string fsItemName )
        {
            this.FsItemName = fsItemName;
            this.FsItemPath = Path.Combine( Path.GetTempPath(), this.FsItemName );

            this.Create();

            return;
        }

        public TempCreateFsItem() : this( XeRandom.RandomString() )
        {
            return;
        }


        protected abstract void Create();


        protected abstract void Delete();


        public void /*IDisposable.*/Dispose()
        {
            this.Delete();
            return;
        }


        protected string FsItemName { get; private set; }


        protected string FsItemPath { get; private set; }
    }


    internal class TempCreateFile : TempCreateFsItem, IDisposable
    {
        public TempCreateFile( string fileName ) : base( fileName )
        {
        }

        public TempCreateFile() : base()
        {
        }


        protected override void Create()
        {
            using ( var writer = File.CreateText( this.FilePath ) )
            {
                writer.WriteLine( XeRandom.RandomString() );
            }
            return;
        }


        protected override void Delete()
        {
            File.Delete( this.FilePath );
            return;
        }


        public string FileName { get { return this.FsItemName; } }


        public string FilePath { get { return this.FsItemPath; } }

    }


    internal class TempCreateFolder : TempCreateFsItem, IDisposable
    {
        public TempCreateFolder( string folderName ) : base( folderName )
        {
        }

        public TempCreateFolder() : base()
        {
        }


        protected override void Create()
        {
            Directory.CreateDirectory( this.FolderPath );
            return;
        }


        protected override void Delete()
        {
            Directory.Delete( this.FolderPath );
            return;
        }


        public string FolderName { get { return this.FsItemName; } }


        public string FolderPath { get { return this.FsItemPath; } }
    }
}
