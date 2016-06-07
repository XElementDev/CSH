using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    [TestClass]
    public class testTitleSimilarity
    {
        [TestMethod]
        public void testTitleSimilarity_Similarity_EqualInput()
        {
            var expected = "ANNO 2070";
            var actual = "Anno 2070™";
            var target = new TitleSimilarity();

            var similarity = target.Similarity( expected, actual );

            Assert.AreEqual( 1, similarity );
        }

        [TestMethod]
        public void testTitleSimilarity_Similarity_PreparedLongerInputShorterThanPreparedShorterInput()
        {
            var expected    = "Plants vs. Zombies";
            var actual      = "Farm for your life";
            var target = new TitleSimilarity();

            var similarity = target.Similarity( expected, actual );

            Assert.AreEqual( 0, similarity, 0.2F );
        }
    }
}
