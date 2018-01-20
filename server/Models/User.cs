using System.Collections.Generic;

namespace poptwit.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string UID { get; set; }

        public List<TweetComparison> Comparisons { get; set; }
    }
}