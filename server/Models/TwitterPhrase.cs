namespace poptwit.Models
{
    public class TwitterPhrase
    {
        public bool IsMostPopular { get; set; }
        public string Phrase { get; set; }
        public long MatchCount { get; set; }
    }
}