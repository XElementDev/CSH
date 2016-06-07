using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using Telerik.JustMock;
using XElement.CloudSyncHelper.UI.Win32.Model;
using SyncObjectsViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects.ViewModel;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SyncObjects
{
    [TestClass]
    public class testViewModel
    {
        [TestInitialize]
        public void TestInitialize()
        {
            this.ResetParameters();
        }


        [TestCleanup]
        public void TestCleanup()
        {
            this.ResetParameters();
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
            this.InitializeTargetViaMef();

            Assert.IsInstanceOfType( this._target, typeof( INotifyPropertyChanged ) );
        }


        [TestMethod]
        public void testSyncObjectsViewModel_HasEntries_False()
        {
            this.InitializeTargetViaMef();
            var items = this._target.SyncObjectViewModelsView.SourceCollection
                                .OfType<object>().ToList();
            foreach ( var item in items )
            {
                this._target.SyncObjectViewModelsView.Remove( item );
            }

            Assert.AreEqual( 0, this._target.SyncObjectViewModelsView.Count );
            Assert.IsFalse( this._target.HasEntries );
        }

        [TestMethod]
        public void testSyncObjectsViewModel_HasEntries_True__RandomValues()
        {
            this.InitializeTargetViaMef();
            for ( int i = 0 ; i < XeRandom.RandomInt( 1, 12 ) ; ++i )
            {
                var syncObjectVmMock = Mock.Create<SyncObject.ViewModel>();
                this._target.SyncObjectViewModelsView.AddNewItem( syncObjectVmMock );
            }

            Assert.AreNotEqual( 0, this._target.SyncObjectViewModelsView.Count );
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
            ((INotifyPropertyChanged)this._target).PropertyChanged += 
                ( s, e ) => eventName = e.PropertyName;

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

            container.ComposeExportedValue( this._syncObjectsModel );

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


        private void ResetParameters()
        {
            this._syncObjectsModel = Mock.Create<SyncObjects.Model>( Behavior.Strict );
            this._target = null;
        }


        private SyncObjects.Model _syncObjectsModel;


        [Import]
        private SyncObjectsViewModel _target;


        private class MefImportTestHelper
        {
            [Import]
            public SyncObjectsViewModel SyncObjectsVM { get; private set; }
        }
    }
}
