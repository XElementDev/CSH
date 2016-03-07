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

            var actual = target.Similarity( "Age of Empires II: HD Edition", "Age of Empires II HD" );

            Assert.AreEqual( 1, actual, 0.3F );
        }

        [TestMethod]
        public void testTitleComparer_Compare_PositiveCase_2()
        {
            var expectedName = "Middle-earth: Shadow of Mordor";
            var crawledName = "Middle-earth™: Shadow of Mordor™";
            var target = new TitleComparer();

            var actual = target.Similarity( expectedName, crawledName );

            Assert.AreEqual( 1, actual, 0.1F );
        }

        [TestMethod]
        public void testTitleComparer_Compare_PositiveCase_3()
        {
            var expectedName = "ANNO 2070";
            var crawledName = "Anno 2070™";
            var target = new TitleComparer();

            var actual = target.Similarity( expectedName, crawledName );

            Assert.AreEqual( 1, actual, 0.1F );
        }

        [TestMethod]
        public void testTitleComparer_Compare_NegativeCase_SomeValue()
        {
            var target = new TitleComparer();

            var actual = target.Similarity( "Exact Audio Copy", "Liquid Rhythm Push Control" );

            Assert.AreEqual( 0, actual, 0.05F );
        }

        [TestMethod]
        public void testTitleComparer_Compare_NegativeCase_OtherValue()
        {
            var target = new TitleComparer();

            var actual = target.Similarity( "Battlefield 3", "Battlefield: Bad Company 2 Vietnam" );

            Assert.AreEqual( 0.2, actual, 0.3F );
        }
    }
}
