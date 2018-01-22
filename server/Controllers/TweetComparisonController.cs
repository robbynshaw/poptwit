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
        private readonly PopContext _context;
        private UserRepo _userRepo = new UserRepo();
        private TweetComparisonRepo _comparisonRepo = new TweetComparisonRepo();

        public TweetComparisonController(PopContext context)
        {
           _context = context; 
        }

        [Route("api/tweetcomparison")]
        [HttpGet]
        public IEnumerable<TweetComparison> Get(int maxCount = 20)
        {
            return _comparisonRepo.GetTop(_context, maxCount);
        }

        [Route("api/tweetcomparison/user")] 
        [HttpGet]
        public IEnumerable<TweetComparison> ByUser(int maxCount = 20)
        {
            return _comparisonRepo.GetForCurrentUser(_context, this.Request, maxCount);
        }

        [Route("api/tweetcomparison")]
        [HttpPut]
        public TweetComparison Put(TweetComparison inputComparison)
        {
            if (ModelState.IsValid)
            {
                return _comparisonRepo.Add(_context, this.Request, inputComparison);
            }
            throw new Exception("Input values are invalid"); // TODO
        }
    }
}