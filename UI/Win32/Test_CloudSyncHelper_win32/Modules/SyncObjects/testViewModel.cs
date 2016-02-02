using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using Telerik.JustMock;
using XElement.CloudSyncHelper.InstalledPrograms;
using XElement.CloudSyncHelper.UI.Win32.Model;
using SyncObjectsViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects.ViewModel;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects
{
    [TestClass]
    public class testViewModel
    {
        [TestCleanup]
        private void TestCleanup()
        {
            this._target = null;
        }



        [TestMethod]
        public void testSyncObjectsViewModel_IsExportedViaMef()
        {
            var mefImport = new MefImportTestHelper();
            var container = this.CreateMefContainer();
            container.ComposeParts( mefImport );

            Assert.IsInstanceOfType( mefImport.SyncObjectsVM, typeof( SyncObjectsViewModel ) );
        }


        [TestMethod]
        public void testSyncObjectsViewModel_ImplementsINotifyPropertyChanged()
        {
            var target = new SyncObjectsViewModel();

            Assert.IsInstanceOfType( target, typeof( INotifyPropertyChanged ) );
        }


        [TestMethod]
        public void testSyncObjectsViewModel_HasEntries_False()
        {
            var target = new SyncObjectsViewModel();
            foreach ( var item in target.ProgramViewModelsView )
            {
                target.ProgramViewModelsView.Remove( item );
            }

            Assert.AreEqual( 0, target.ProgramViewModelsView.Count );
            Assert.IsFalse( target.HasEntries );
        }

        [TestMethod]
        public void testSyncObjectsViewModel_HasEntries_True()
        {
            this.InitializeTargetViaMef();

            Assert.AreNotEqual( 0, this._target.ProgramViewModelsView.Count );
            Assert.IsTrue( this._target.HasEntries );
        }

        [TestMethod]
        public void testSyncObjectsViewModel_HasEntries_IsUpdatedOnFilterChange()
        {
            var filterModel = new FilterModel();
            filterModel.Filter = XeRandom.RandomString();
            this.InitializeTargetViaMef( filterModel );
            bool isCalled = false;
            ((INotifyPropertyChanged)this._target).PropertyChanged += ( s, e ) => isCalled = true;

            filterModel.Filter = XeRandom.RandomString();

            Assert.IsTrue( isCalled );
        }

        [TestMethod]
        public void testSyncObjectsViewModel_HasEntries_IsUpdatedOnFilterChange_RaisesCorrectEvent()
        {
            var filterModel = new FilterModel();
            filterModel.Filter = XeRandom.RandomString();
            this.InitializeTargetViaMef( filterModel );
            string eventName = null;
            ((INotifyPropertyChanged)this._target).PropertyChanged += ( s, e ) => eventName = e.PropertyName;

            filterModel.Filter = XeRandom.RandomString();

            Assert.AreEqual( nameof( this._target.HasEntries ), eventName );
        }



        private ComposablePartCatalog CreateMefCatalog()
        {
            var assembly = typeof( App ).Assembly;
            return new AssemblyCatalog( assembly );
        }

        private CompositionContainer CreateMefContainer()
        {
            var catalog = this.CreateMefCatalog();
            var container = new CompositionContainer( catalog );

            container.ComposeExportedValue( Mock.Create<ConfigForOsHelper>() );
            container.ComposeExportedValue( Mock.Create<IScanner>() );

            return container;
        }

        private void InitializeTargetViaMef()
        {
            this.InitializeTargetViaMef( new FilterModel() );
        }

        private void InitializeTargetViaMef( FilterModel filterModel )
        {
            var container = this.CreateMefContainer();
            container.ComposeExportedValue( filterModel );

            container.ComposeParts( this );
        }


        [Import]
        private SyncObjectsViewModel _target;


        private class MefImportTestHelper
        {
            [Import]
            public SyncObjectsViewModel SyncObjectsVM { get; private set; }
        }
    }
}
