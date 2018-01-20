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
        private UserRepo _userRepo = new UserRepo();
        private TweetComparisonRepo _comparisonRepo = new TweetComparisonRepo();

        [Route("api/tweetcomparison")]
        [HttpGet]
        public IEnumerable<TweetComparison> Get(int maxCount = 20)
        {
            return _comparisonRepo.GetTop(maxCount);
        }

        [Route("api/tweetcomparison/user")] 
        [HttpGet]
        public IEnumerable<TweetComparison> ByUser(int maxCount = 20)
        {
            return _comparisonRepo.GetForCurrentUser(this.Request, maxCount);
        }

        [Route("api/tweetcomparison")]
        [HttpPut]
        public TweetComparison Put(TweetComparison inputComparison)
        {
            return _comparisonRepo.Add(this.Request, inputComparison);
        }
    }
}