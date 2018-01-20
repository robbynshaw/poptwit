using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using poptwit.Models;
using poptwit.Repos;

namespace poptwit.Controllers
{
    public class TweetComparisonController : Controller
    {
        private TweetComparisonRepo _repo = new TweetComparisonRepo();

        [Route("api/tweetcomparison")]
        [HttpGet]
        public IEnumerable<TweetComparison> Get(int maxCount = 20)
        {
            return _repo.GetTop(maxCount);
        }

        [Route("api/tweetcomparison/{username}")] 
        [HttpGet]
        public IEnumerable<TweetComparison> ByUser(string username, int maxCount = 20)
        {
            return _repo.GetByUser(username, maxCount);
        }

        [Route("api/tweetcomparison")]
        [HttpPut]
        public TweetComparison Put(TweetComparison inputComparison)
        {
            return _repo.Add(inputComparison);
        }
    }
}