using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Http;
using poptwit.Models;

namespace poptwit.Repos
{
    internal class TweetComparisonRepo
    {
        private UserRepo _userRepo = new UserRepo();
        private TwitterSearchRepo _tSearchRepo = new TwitterSearchRepo();

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
                    .OrderByDescending(c => c.Created)
                    .Take(maxCount);
            }
        }

        private void LoadPopularity(long comparisonID)
        {
            using (var db = new PopContext())
            {
                TweetComparison comparison = db.Comparisons
                    .Single(c => c.TweetComparisonId == comparisonID);

                comparison.AMatchCount = _tSearchRepo.GetPopularity(comparison.APhrase);
                Console.WriteLine($"Phrase: {comparison.APhrase}, Count: {comparison.AMatchCount}");
                comparison.BMatchCount = _tSearchRepo.GetPopularity(comparison.BPhrase);
                Console.WriteLine($"Phrase: {comparison.BPhrase}, Count: {comparison.BMatchCount}");
                comparison.IsPending = false;

                db.SaveChanges();
            }
        }

        public TweetComparison Add(HttpRequest request, TweetComparison inputComparison)
        {
            inputComparison.Created = DateTime.Now;
            inputComparison.DateRange = TimeSpan.FromDays(7);
            inputComparison.IsPending = true;

            using (PopContext db = new PopContext())
            {
                User user = _userRepo.GetOrCreate(db, request);
                inputComparison.UserId = user.UserId;

                db.Add(inputComparison);
                db.SaveChanges();
            }
            
            new Thread(() => {
                LoadPopularity(inputComparison.TweetComparisonId);
            }).Start();

            return inputComparison;
        }
    }
}