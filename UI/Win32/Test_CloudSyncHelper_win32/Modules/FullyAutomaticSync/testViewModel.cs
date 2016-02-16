using Microsoft.VisualStudio.TestTools.UnitTesting;
using FullyAutomaticSyncViewModel = XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync.ViewModel;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync
{
    [TestClass]
    public class testViewModel
    {
        [TestMethod]
        public void testViewModel_IsLinked_False_BecauseNoSteamCloud()
        {
            var ctorParams = new VmCtorParams
            {
                IsInstalled = true, 
                SupportsSteamCloud = false
            };

            var target = new FullyAutomaticSyncViewModel( ctorParams );

            Assert.IsFalse( target.IsLinked );
        }

        [TestMethod]
        public void testViewModel_IsLinked_False_BecauseNotInstalled()
        {
            var ctorParams = new VmCtorParams
            {
                IsInstalled = false,
                SupportsSteamCloud = true
            };

            var target = new FullyAutomaticSyncViewModel( ctorParams );

            Assert.IsFalse( target.IsLinked );
        }

        [TestMethod]
        public void testViewModel_IsLinked_True()
        {
            var ctorParams = new VmCtorParams
            {
                IsInstalled = true,
                SupportsSteamCloud = true
            };

            var target = new FullyAutomaticSyncViewModel( ctorParams );

            Assert.IsTrue( target.IsLinked );
        }


        [TestMethod]
        public void testViewModel_SupportsSteamCloud_False()
        {
            var ctorParams = new VmCtorParams
            {
                IsInstalled = XeRandom.RandomBool(),
                SupportsSteamCloud = false
            };

            var target = new FullyAutomaticSyncViewModel( ctorParams );

            Assert.IsFalse( target.SupportsSteamCloud );
        }

        [TestMethod]
        public void testViewModel_SupportsSteamCloud_True()
        {
            var ctorParams = new VmCtorParams { SupportsSteamCloud = true };

            var target = new FullyAutomaticSyncViewModel( ctorParams );

            Assert.IsTrue( target.SupportsSteamCloud );
        }



        private class VmCtorParams : IViewModelConstructorParameters
        {
            public bool /*IViewModelConstructorParameters.*/IsInstalled { get; set; }
            public bool /*IViewModelConstructorParameters.*/SupportsSteamCloud { get; set; }
        }
    }
}
