using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    internal class TitleSimilarity
    {
        private string GetPreparedInput( string input )
        {
            return this.StripInvalidChars( input ).ToLower();
        }

        public float Similarity( string expected, string actual )
        {
            float matchRatio = 0;

            var preparedExpectedInput = this.GetPreparedInput( expected );
            var preparedActualInput = this.GetPreparedInput( actual );

            if ( preparedActualInput.Length > preparedExpectedInput.Length )
                matchRatio = this.SimilarityLengthSortedAndPrepared( preparedLongerInput: preparedActualInput, 
                                                                     preparedShorterInput: preparedExpectedInput );
            else
                matchRatio = this.SimilarityLengthSortedAndPrepared( preparedLongerInput: preparedExpectedInput, 
                                                                     preparedShorterInput: preparedActualInput );

            return matchRatio;
        }

        private float SimilarityLengthSortedAndPrepared( string preparedLongerInput, 
                                                         string preparedShorterInput )
        {
            int matchCount = 0;

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
