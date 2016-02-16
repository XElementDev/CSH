using Microsoft.VisualStudio.TestTools.UnitTesting;
using FullyAutomaticSyncModel = XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync.Model;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync
{
    [TestClass]
    public class testModel
    {
        [TestMethod]
        public void testModel_IsLinked_False_BecauseNoSteamCloud()
        {
            var ctorParams = new ModelCtorParams
            {
                IsInstalled = true, 
                SupportsSteamCloud = false
            };

            var target = new FullyAutomaticSyncModel( ctorParams );

            Assert.IsFalse( target.IsLinked );
        }

        [TestMethod]
        public void testModel_IsLinked_False_BecauseNotInstalled()
        {
            var ctorParams = new ModelCtorParams
            {
                IsInstalled = false,
                SupportsSteamCloud = true
            };

            var target = new FullyAutomaticSyncModel( ctorParams );

            Assert.IsFalse( target.IsLinked );
        }

        [TestMethod]
        public void testModel_IsLinked_True()
        {
            var ctorParams = new ModelCtorParams
            {
                IsInstalled = true,
                SupportsSteamCloud = true
            };

            var target = new FullyAutomaticSyncModel( ctorParams );

            Assert.IsTrue( target.IsLinked );
        }


        [TestMethod]
        public void testModel_SupportsSteamCloud_False()
        {
            var ctorParams = new ModelCtorParams
            {
                IsInstalled = XeRandom.RandomBool(),
                SupportsSteamCloud = false
            };

            var target = new FullyAutomaticSyncModel( ctorParams );

            Assert.IsFalse( target.SupportsSteamCloud );
        }

        [TestMethod]
        public void testModel_SupportsSteamCloud_True()
        {
            var ctorParams = new ModelCtorParams { SupportsSteamCloud = true };

            var target = new FullyAutomaticSyncModel( ctorParams );

            Assert.IsTrue( target.SupportsSteamCloud );
        }



        private class ModelCtorParams : IModelConstructorParameters
        {
            public bool /*IModelConstructorParameters.*/IsInstalled { get; set; }
            public bool /*IModelConstructorParameters.*/SupportsSteamCloud { get; set; }
        }
    }
}
