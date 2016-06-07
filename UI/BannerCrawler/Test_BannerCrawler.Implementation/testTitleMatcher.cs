using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using XElement.DotNet.System.Text;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    [TestClass]
    public class testTitleMatcher
    {
        [TestMethod]
        public void testTitleMatcher_GetBestMatchingTitle_PositiveCase_1()
        {
            var target = new TitleMatcher();
            var searchInput = "Age of Empires II: HD Edition";
            var expectedBestMatch = "Age of Empires II HD";
            var titles = new List<string> { expectedBestMatch, "Age of Mythology: Extended Edition" };

            var actualBestMatch = target.GetBestMatchingTitle( searchInput, titles );

            Assert.AreEqual( expectedBestMatch, actualBestMatch );
        }

        [TestMethod]
        public void testTitleMatcher_GetBestMatchingTitle_PositiveCase_2()
        {
            var target = new TitleMatcher();
            var searchInput = "Middle-earth: Shadow of Mordor";
            var expectedBestMatch = "Middle-earth™: Shadow of Mordor™";
            var titles = new List<string> { expectedBestMatch };

            var actualBestMatch = target.GetBestMatchingTitle( searchInput, titles );

            Assert.AreEqual( expectedBestMatch, actualBestMatch );
        }

        [TestMethod]
        public void testTitleMatcher_GetBestMatchingTitle_PositiveCase_3()
        {
            var target = new TitleMatcher();
            var searchInput = "ANNO 2070";
            var expectedBestMatch = "Anno 2070™";
            var titles = new List<string> { expectedBestMatch };

            var actualBestMatch = target.GetBestMatchingTitle( searchInput, titles );

            Assert.AreEqual( expectedBestMatch, actualBestMatch );
        }

        [TestMethod]
        public void testTitleMatcher_GetBestMatchingTitle_PositiveCase_4()
        {
            var target = new TitleMatcher();
            var searchInput = "Borderlands";
            var expectedBestMatch = searchInput;
            var titles = new List<string> { "Borderlands 2", "Tales from the Borderlands", 
                                            "Borderlands: The Pre-Sequel", expectedBestMatch };

            var actualBestMatch = target.GetBestMatchingTitle( searchInput, titles );

            Assert.AreEqual( expectedBestMatch, actualBestMatch );
        }

        [TestMethod]
        [ExpectedException( typeof( Exception ) )]
        public void testTitleMatcher_GetBestMatchingTitle_NegativeCase_1()
        {
            var target = new TitleMatcher();
            var searchInput = "Exact Audio Copy";
            var titles = new List<string> { "Liquid Rhythm Push Control" };

            var irrelevant = target.GetBestMatchingTitle( searchInput, titles );
        }

        [TestMethod]
        [ExpectedException( typeof( Exception ) )]
        public void testTitleMatcher_GetBestMatchingTitle_NegativeCase_2()
        {
            var target = new TitleMatcher();
            var searchInput = "Battlefield 3";
            var titles = new List<string>
            {
                $"Battlefield: Bad Company{SpecialCharacters.TRADEMARK} 2", 
                "Battlefield: Bad Company 2 Vietnam", 
                "Battlefield 2: Complete Collection"
            };

            var irrelevant = target.GetBestMatchingTitle( searchInput, titles );
        }
    }
}
