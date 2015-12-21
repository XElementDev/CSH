using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
    internal class TitleComparer
    {
        public bool Compare( string expected, string actual )
        {
            float matchRatio = 0;

            if ( actual.Length > expected.Length )
                matchRatio = this.CompareLengthSorted( longerInput: actual, shorterInput: expected );
            else
                matchRatio = this.CompareLengthSorted( longerInput: expected, shorterInput: actual );

            return matchRatio > THRESHOLD;
        }

        private float CompareLengthSorted( string longerInput, string shorterInput )
        {
            int matchCount = 0;

            var strippedLongerInput = this.StripInvalidChars( longerInput );
            var strippedShorterInput = this.StripInvalidChars( shorterInput );

            for ( int i = 0 ; i < strippedShorterInput.Length ; ++i )
            {
                if ( strippedShorterInput[i] == strippedLongerInput[i] )
                {
                    ++matchCount;
                }
            }

            return (float)matchCount / (float)strippedLongerInput.Length;
        }

        private string StripInvalidChars( string input )
        {
            var regexMatches = Regex.Matches( input, REGEX_VALID_CHARS );
            List<string> matchList = regexMatches.OfType<Match>().Select( m => m.Value ).ToList();
            var joinedString = String.Join( "", matchList );
            return joinedString;
        }

        private const string REGEX_VALID_CHARS = "[a-zA-z\\-\\ ]";
        private const float THRESHOLD = 0.5F;
    }
}
