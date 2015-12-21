using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class testTitleComparer
    {
        [TestMethod]
        public void testTitleComparer_Compare_PositiveCase_SomeValue()
        {
            var target = new TitleComparer();

            Assert.IsTrue( target.Compare( "Age of Empires II: HD Edition", "Age of Empires II HD" ) );
        }

        [TestMethod]
        public void testTitleComparer_Compare_NegativeCase_SomeValue()
        {
            var target = new TitleComparer();

            Assert.IsFalse( target.Compare( "Exact Audio Copy", "Liquid Rhythm Push Control" ) );
        }

        [TestMethod]
        public void testTitleComparer_Compare_NegativeCase_OtherValue()
        {
            var target = new TitleComparer();

            Assert.IsFalse( target.Compare( "Battlefield 3", "Battlefield: Bad Company 2 Vietnam" ) );
        }
    }
}
