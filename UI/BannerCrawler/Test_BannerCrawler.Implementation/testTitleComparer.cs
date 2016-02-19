using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class testTitleComparer
    {
        [TestMethod]
        public void testTitleComparer_Compare_PositiveCase_1()
        {
            var target = new TitleComparer();

            Assert.IsTrue( target.Compare( "Age of Empires II: HD Edition", "Age of Empires II HD" ) );
        }

        [TestMethod]
        public void testTitleComparer_Compare_PositiveCase_2()
        {
            var expectedName = "Middle-earth: Shadow of Mordor";
            var crawledName = "Middle-earth™: Shadow of Mordor™";
            var target = new TitleComparer();

            Assert.IsTrue( target.Compare( expectedName, crawledName ) );
        }

        [TestMethod]
        public void testTitleComparer_Compare_PositiveCase_3()
        {
            var expectedName = "ANNO 2070";
            var crawledName = "Anno 2070™";
            var target = new TitleComparer();

            Assert.IsTrue( target.Compare( expectedName, crawledName ) );
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
