using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator
{
    [TestClass]
    public class testDataManager
    {
        [TestCleanup]
        private void TestCleanup()
        {
            this._target = null;
        }



        [TestMethod]
        public void testDataManager_IsExportedViaMef()
        {
            var mefImport = new MefImportTestHelper();
            var container = this.CreateMefContainer();
            container.ComposeParts( mefImport );

            Assert.IsInstanceOfType( mefImport.DataManager, typeof( DataManager ) );
        }


        [TestMethod]
        public void testDataManager_SyncData_Get_AllEntriesHaveAnUniqueID()
        {
            this.InitializeTargetViaMef();

            var ids = this._target.SyncData.ApplicationInfos.Select( ai => ai.Id ).ToList();
            CollectionAssert.AllItemsAreUnique( ids );
        }

        [TestMethod]
        public void testDataManager_SyncData_Get_ContainsGames()
        {
            this.InitializeTargetViaMef();

            var games = this._target.SyncData.ApplicationInfos.OfType<IGameInfo>().ToList();
            Assert.AreNotEqual( 0, games.Count );
        }

        [TestMethod]
        public void testDataManager_SyncData_Get_ContainsTools()
        {
            this.InitializeTargetViaMef();

            var tools = this._target.SyncData.ApplicationInfos.OfType<IToolInfo>().ToList();
            Assert.AreNotEqual( 0, tools.Count );
        }



        private ComposablePartCatalog CreateMefCatalog()
        {
            var assembly = typeof( Program ).Assembly;
            return new AssemblyCatalog( assembly );
        }

        private CompositionContainer CreateMefContainer()
        {
            var catalog = this.CreateMefCatalog();
            var container = new CompositionContainer( catalog );

            return container;
        }

        private void InitializeTargetViaMef()
        {
            var container = this.CreateMefContainer();
            container.ComposeParts( this );
        }


        [Import]
        private DataManager _target;


        private class MefImportTestHelper
        {
            [Import]
            public DataManager DataManager { get; private set; }
        }
    }
}
