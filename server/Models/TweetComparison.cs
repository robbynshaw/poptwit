using System;
using Newtonsoft.Json;

namespace poptwit.Models
{
    public class TweetComparison
    {
        public long TweetComparisonId { get; set; }
        public long UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public DateTime Created { get; set; }
        public TimeSpan DateRange { get; set; }
        public bool AIsMostPopular { get { return AMatchCount > BMatchCount; } }
        public string APhrase { get; set; }
        public long AMatchCount { get; set; }
        public bool BIsMostPopular { get { return BMatchCount > AMatchCount; } }
        public string BPhrase { get; set; }
        public long BMatchCount { get; set; }
    }
}