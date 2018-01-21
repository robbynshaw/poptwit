using System;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Parameters;

namespace poptwit.Repos
{
    public class TwitterSearchRepo
    {
        private string _baseUri = Settings.TwitterPremiumSearchBaseAPI;

        static TwitterSearchRepo()
        {
            Auth.SetUserCredentials(
                Settings.TwitterKey,
                Settings.TwitterSecret,
                Settings.TwitterAccessToken,
                Settings.TwitterAccessTokenSecret
                );
        }

        public long GetPopularity(string phrase)
        {
            var searchParams = new SearchTweetsParameters($"\"{phrase}\"")
            {
                MaximumNumberOfResults = 10000
            };
            return Search.SearchTweets(searchParams).Count();

        }
    }
}