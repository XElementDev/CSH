using System;
using System.Collections.Generic;
using System.Linq;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    internal class TitleMatcher
    {
        public TitleMatcher()
        {
            this._titleSimilarity = new TitleSimilarity();
        }

        public string GetBestMatchingTitle( string searchInput, IEnumerable<string> titles )
        {
            var titleToSimilarityMap = new Dictionary<string, float>();
            foreach ( var title in titles )
            {
                titleToSimilarityMap.Add( title, this._titleSimilarity.Similarity( searchInput, title ) );
            }

            var maxSimilarity = titleToSimilarityMap.Max( kvp => kvp.Value );
            if ( maxSimilarity > THRESHOLD )
            {
                var firstEntryWithMaxSimilairty = titleToSimilarityMap.First( kvp => kvp.Value == maxSimilarity );
                return firstEntryWithMaxSimilairty.Key;
            }
            else
            {
                throw new Exception();  // TODO: Should I throw this TYPE of exception?
            }
        }

        private const float THRESHOLD = 0.5F;

        private TitleSimilarity _titleSimilarity;
    }
}
