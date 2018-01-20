using System.Collections.Generic;
using poptwit.Models;

namespace poptwit.Repos
{
    internal class TweetComparisonRepo
    {
        public IEnumerable<TweetComparison> GetByUser(string username, int maxCount)
        {
            return new List<TweetComparison>()
            {
                new TweetComparison()
                {
                    PhraseA = new TwitterPhrase()
                    {
                        Phrase = "Hello There",
                        MatchCount = 123,
                        IsMostPopular = true,
                    },
                    PhraseB = new TwitterPhrase()
                    {
                        Phrase = "Hi Boy",
                        MatchCount = 1,
                    }
                }
            };

        }

        public IEnumerable<TweetComparison> GetTop(int maxCount)
        {
            return new List<TweetComparison>()
            {
                new TweetComparison()
                {
                    PhraseA = new TwitterPhrase()
                    {
                        Phrase = "Hello",
                        MatchCount = 123,
                        IsMostPopular = true,
                    },
                    PhraseB = new TwitterPhrase()
                    {
                        Phrase = "Hi",
                        MatchCount = 1,
                    }
                }
            };
        }
    }
}