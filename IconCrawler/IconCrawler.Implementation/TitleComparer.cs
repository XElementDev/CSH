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

            for ( int i = 0 ; i < shorterInput.Length ; ++i )
            {
                if ( shorterInput[i] == longerInput[i] )
                {
                    ++matchCount;
                }
            }

            return (float)matchCount / (float)longerInput.Length;
        }

        private const float THRESHOLD = 0.5F;
    }
}
