using Microsoft.VisualStudio.TestTools.UnitTesting;
using FullyAutomaticSyncViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync.ViewModel;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync
{
    [TestClass]
    public class testViewModel
    {
        [TestMethod]
        public void testViewModel_Constructor_SetsProperties_False()
        {
            var ctorParams = new VmCtorParams { SupportsSteamCloud = false };

            var target = new FullyAutomaticSyncViewModel( ctorParams );

            Assert.IsFalse( target.IsLinked );
            Assert.IsFalse( target.SupportsSteamCloud );
        }

        [TestMethod]
        public void testViewModel_Constructor_SetsProperties_True()
        {
            var ctorParams = new VmCtorParams { SupportsSteamCloud = true };

            var target = new FullyAutomaticSyncViewModel( ctorParams );

            Assert.IsTrue( target.IsLinked );
            Assert.IsTrue( target.SupportsSteamCloud );
        }



        private class VmCtorParams : IViewModelConstructorParameters
        {
            public bool /*IViewModelConstructorParameters.*/SupportsSteamCloud { get; set; }
        }
    }
}
