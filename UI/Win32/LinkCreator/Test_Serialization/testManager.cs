using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using XElement.CloudSyncHelper.Logic.Execution.MkLink;
using MkLinkType = XElement.CloudSyncHelper.Logic.Execution.MkLink.Type;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.CloudSyncHelper.UI.Win32.LinkCreator.Serialization
{
    [TestClass]
    public class testManager
    {
        [TestMethod]
        public void testManager_Constructor_ImplementsIManager()
        {
            var target = new Manager();

            Assert.IsInstanceOfType( target, typeof( IManager ) );
        }


        [TestMethod]
        public void testManager_Roundtrip__SomeValues()
        {
            var expectedParameters = new ParametersDTO
            {
                Link = @"C:\link.txt", 
                Target = @"C:\target.txt", 
                Type = MkLinkType.FILE_LINK
            };
            IManager target = new Manager();

            var serialized = target.Serialize( expectedParameters );
            var actualParameters = target.Deserialize( serialized );

            Assert.AreEqual( expectedParameters.Link, actualParameters.Link );
            Assert.AreEqual( expectedParameters.Target, actualParameters.Target );
            Assert.AreEqual( expectedParameters.Type, actualParameters.Type );
        }

        [TestMethod]
        public void testManager_Roundtrip__RandomValues()
        {
            var expectedParameters = new ParametersDTO
            {
                Link = XeRandom.RandomString(), 
                Target = XeRandom.RandomString(), 
                Type = testManager.RandomEnumValue<MkLinkType>()
            };
            IManager target = new Manager();

            var serialized = target.Serialize( expectedParameters );
            var actualParameters = target.Deserialize( serialized );

            Assert.AreEqual( expectedParameters.Link, actualParameters.Link );
            Assert.AreEqual( expectedParameters.Target, actualParameters.Target );
            Assert.AreEqual( expectedParameters.Type, actualParameters.Type );
        }



        // TODO: Move this method to TestUtils project
        private static T RandomEnumValue<T>()
        {
            Enum.GetUnderlyingType( typeof( T ) );  // Throws an exception if type is not an enum.
            var enumValues = Enum.GetValues( typeof( T ) ).OfType<T>().ToArray();
            var randomEnumValue = XeRandom.RandomTFromArrayOf( enumValues );
            return randomEnumValue;
        }
    }
}
