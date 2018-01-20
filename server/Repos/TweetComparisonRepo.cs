using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using poptwit.Models;

namespace poptwit.Repos
{
    internal class TweetComparisonRepo
    {
        private UserRepo _userRepo = new UserRepo();

        public IEnumerable<TweetComparison> GetTop(int maxCount)
        {
            return new List<TweetComparison>()
            {
                new TweetComparison()
                {
                    APhrase = "Hello",
                    AMatchCount = 123,
                    BPhrase = "Hi",
                    BMatchCount = 1,
                }
            };
        }
        
        public IEnumerable<TweetComparison> GetForCurrentUser(HttpRequest request, int maxCount)
        {
            using (var db = new PopContext())
            {
                User user = _userRepo.GetOrCreate(db, request);
                db.Entry(user)
                    .Collection(u => u.Comparisons)
                    .Load();
                return user.Comparisons
                    .OrderBy(c => c.Created)
                    .Take(maxCount);
            }
        }

        public TweetComparison Add(HttpRequest request, TweetComparison inputComparison)
        {
            inputComparison.AMatchCount = 20;
            inputComparison.BMatchCount = 30;
            
            using (PopContext db = new PopContext())
            {
                User user = _userRepo.GetOrCreate(db, request);
                inputComparison.UserId = user.UserId;

                db.Add(inputComparison);
                db.SaveChanges();
            }

            return inputComparison;
        }
    }
}