using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Windows.Input;
using Telerik.JustMock;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.CloudSyncHelper.UI.Win32.Modules.ApplicationMenu;
using FilterViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.Filter.ViewModel;
using MenuBarViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.MenuBar.ViewModel;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.MenuBar
{
    [TestClass]
    public class testViewModel
    {
        [TestInitialize]
        public void TestInitialize()
        {
            this._mefParameters = new MefParameters();
            this._mefParameters.AppMenuContainer = Mock.Create<IApplicationMenuContainer>();
            this._mefParameters.FilterModel = Mock.Create<FilterModel>();
            this._mefParameters.UserProfileContainer = 
                Mock.Create<UserProfileContainer>( Behavior.Strict );
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this._mefParameters = null;
            this._target = null;
        }



        [TestMethod]
        public void testMenuBarVM_IsExportedViaMef()
        {
            var mefImport = new MefImportTestHelper();
            var container = this.CreateMefContainer();
            container.ComposeParts( mefImport );

            Assert.IsInstanceOfType( mefImport.MenuBarVM, typeof( MenuBarViewModel ) );
        }


        [TestMethod]
        public void testMenuBarVM_ImplementsINotifyPropertyChanged()
        {
            this.InitializeTargetViaMef();

            Assert.IsInstanceOfType( this._target, typeof( INotifyPropertyChanged ) );
        }


        [TestMethod]
        public void testMenuBarVM_Constructor_InitializesSubElements()
        {
            this.InitializeTargetViaMef();

            Assert.IsNotNull( this._target.FilterVM );
            Assert.IsInstanceOfType( this._target.FilterVM, typeof( FilterViewModel ) );
            Assert.IsNotNull( this._target.ShowApplicationMenu );
            Assert.IsInstanceOfType( this._target.ShowApplicationMenu, typeof( ICommand ) );
            Assert.IsNotNull( this._target.UserProfileContainer );
            Assert.IsInstanceOfType( this._target.UserProfileContainer, typeof( UserProfileContainer ) );
        }


        [TestMethod]
        public void testMenuBarVM_IsFilterVisible_GetSet()
        {
            this.InitializeTargetViaMef();

            this._target.IsFilterVisible = true;
            Assert.IsTrue( this._target.IsFilterVisible );
            this._target.IsFilterVisible = false;
            Assert.IsFalse( this._target.IsFilterVisible );
        }

        [TestMethod]
        public void testMenuBarVM_IsFilterVisible_ClearFilterOnFalse()
        {
            var filterModelMock = Mock.Create<FilterModel>();
            filterModelMock.Filter = XeRandom.RandomString();
            this._mefParameters.FilterModel = filterModelMock;
            this.InitializeTargetViaMef();

            this._target.IsFilterVisible = false;

            Assert.AreEqual( String.Empty, filterModelMock.Filter );
        }

        [TestMethod]
        public void testMenuBarVM_IsFilterVisible_Set_RaisesPropertyChanged__RandomValue()
        {
            bool propertyChangedRaised = false;
            this.InitializeTargetViaMef();
            this._target.PropertyChanged += ( s, e ) => propertyChangedRaised = true;

            this._target.IsFilterVisible = XeRandom.RandomBool();

            Assert.IsTrue( propertyChangedRaised );
        }

        [TestMethod]
        public void testMenuBarVM_IsFilterVisible_Set_RaisesPropertyChangedInCorrectOrder__RandomValue()
        {
            bool expected = XeRandom.RandomBool();
            bool actual = !expected;
            this.InitializeTargetViaMef();
            this._target.PropertyChanged += ( s, e ) => actual = this._target.IsFilterVisible;

            this._target.IsFilterVisible = expected;

            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void testMenuBarVM_IsFilterVisible_Set_RaisesPropertyChangedWithCorrectParameter__RandomValue()
        {
            this.InitializeTargetViaMef();
            var expectedPropertyName = nameof( this._target.IsFilterVisible );
            string actualPropertyName = null;
            this._target.PropertyChanged += ( s, e ) => actualPropertyName = e.PropertyName;

            this._target.IsFilterVisible = XeRandom.RandomBool();

            Assert.AreEqual( expectedPropertyName, actualPropertyName );
        }


        [TestMethod]
        public void testMenuBarVM_ShowApplicationMenu_CallsIApplicationMenuContainer()
        {
            var appMenuContainerMock = Mock.Create<IApplicationMenuContainer>();
            Mock.Arrange( () => appMenuContainerMock.ShowApplicationMenu() ).MustBeCalled();
            this._mefParameters.AppMenuContainer = appMenuContainerMock;
            this.InitializeTargetViaMef();

            this._target.ShowApplicationMenu.Execute( "irrelevant" );

            Mock.Assert( appMenuContainerMock );
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

            container.ComposeExportedValue<IApplicationMenuContainer>( this._mefParameters.AppMenuContainer );
            container.ComposeExportedValue<FilterModel>( this._mefParameters.FilterModel );
            container.ComposeExportedValue<UserProfileContainer>( this._mefParameters.UserProfileContainer );

            return container;
        }


        private void InitializeTargetViaMef()
        {
            var container = this.CreateMefContainer();
            container.ComposeParts( this );
        }


        [Import]
        private MenuBarViewModel _target;


        private MefParameters _mefParameters;


        private class MefImportTestHelper
        {
            [Import]
            public MenuBarViewModel MenuBarVM { get; private set; }
        }


        private class MefParameters
        {
            public IApplicationMenuContainer AppMenuContainer { get; set; }
            public FilterModel FilterModel { get; set; }
            public UserProfileContainer UserProfileContainer { get; set; }
        }
    }
}
