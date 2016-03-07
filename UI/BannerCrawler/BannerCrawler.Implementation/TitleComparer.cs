using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    internal class TitleComparer
    {
        private string GetPreparedInput( string input )
        {
            return this.StripInvalidChars( input ).ToLower();
        }

        public float Similarity( string expected, string actual )
        {
            float matchRatio = 0;

            if ( actual.Length > expected.Length )
                matchRatio = this.SimilarityLengthSorted( longerInput: actual, shorterInput: expected );
            else
                matchRatio = this.SimilarityLengthSorted( longerInput: expected, shorterInput: actual );

            return matchRatio;
        }

        private float SimilarityLengthSorted( string longerInput, string shorterInput )
        {
            int matchCount = 0;

            var preparedLongerInput = this.GetPreparedInput( longerInput );
            var preparedShorterInput = this.GetPreparedInput( shorterInput );

            for ( int i = 0 ; i < preparedShorterInput.Length ; ++i )
            {
                if ( preparedShorterInput[i] == preparedLongerInput[i] )
                {
                    ++matchCount;
                }
            }

            return (float)matchCount / (float)preparedLongerInput.Length;
        }

        private string StripInvalidChars( string input )
        {
            var regexMatches = Regex.Matches( input, REGEX_VALID_CHARS );
            List<string> matchList = regexMatches.OfType<Match>().Select( m => m.Value ).ToList();
            var joinedString = String.Join( "", matchList );
            return joinedString;
        }

        private const string REGEX_VALID_CHARS = "[a-zA-z\\-\\ ]";
    }
}
