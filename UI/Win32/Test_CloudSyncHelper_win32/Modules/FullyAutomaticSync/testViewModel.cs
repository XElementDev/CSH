using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync
{
    [TestClass]
    public class testViewModel
    {
        [TestMethod]
        public void testViewModel_Model_IsSetViaCtor()
        {
            var irrelevant = Mock.Create</*FullyAutomaticSync.*/IModelConstructorParameters>();
            var model = new /*FullyAutomaticSync.*/Model( irrelevant );

            var target = new /*FullyAutomaticSync.*/ViewModel( model );

            Assert.IsNotNull( target.Model );
            Assert.AreEqual( model, target.Model );
        }
    }
}
