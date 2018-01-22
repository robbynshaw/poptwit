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

        public bool Exists(PopContext db, DateTime date, string phraseA, string phraseB)
        {
            return db.Comparisons
                .SingleOrDefault(c => c.Created.Date == date.Date
                    && c.APhrase.Equals(phraseA, StringComparison.InvariantCultureIgnoreCase)
                    && c.BPhrase.Equals(phraseB, StringComparison.InvariantCultureIgnoreCase)
                    ) != null;
        }

        public IEnumerable<TweetComparison> GetTop(PopContext db, int maxCount)
        {
            return db.Comparisons
                .OrderByDescending(c => c.Created)
                .Take(maxCount)
                .ToList();
        }

        public IEnumerable<TweetComparison> GetForCurrentUser(PopContext db, HttpRequest request, int maxCount)
        {
            User user = _userRepo.GetOrCreate(db, request);
            db.Entry(user)
                .Collection(u => u.Comparisons)
                .Load();
            return user.Comparisons
                .OrderByDescending(c => c.Created)
                .Take(maxCount);
        }

        private void LoadPopularity(long comparisonID)
        {
            using (var db = new PopContextSingleton())
            {
                TweetComparison comparison = db.Comparisons
                    .Single(c => c.TweetComparisonId == comparisonID);

                Console.WriteLine($"Getting popularity for '{comparison.APhrase}'...");
                comparison.AMatchCount = _tSearchRepo.GetPopularity(comparison.APhrase);
                comparison.AIsPending = false;
                Console.WriteLine($"'{comparison.APhrase}' = {comparison.AMatchCount}");
                db.SaveChanges();

                Console.WriteLine($"Getting popularity for '{comparison.BPhrase}'...");
                comparison.BMatchCount = _tSearchRepo.GetPopularity(comparison.BPhrase);
                Console.WriteLine($"'{comparison.APhrase}' = {comparison.AMatchCount}");
                comparison.BIsPending = false;

                db.SaveChanges();
            }
        }

        public TweetComparison Add(PopContext db, HttpRequest request, TweetComparison inputComparison)
        {
            // TODO Sql translation doesn't work
            // if (Exists(db, DateTime.Now, inputComparison.APhrase, inputComparison.BPhrase))
            // {
            //     throw new Exception("Comparison already exists today");
            // }

            inputComparison.Created = DateTime.Now;
            inputComparison.DateRange = TimeSpan.FromDays(7);
            inputComparison.AIsPending = true;
            inputComparison.BIsPending = true;

            User user = _userRepo.GetOrCreate(db, request);
            inputComparison.UserId = user.UserId;

            db.Add(inputComparison);
            db.SaveChanges();

            new Thread(() =>
            {
                LoadPopularity(inputComparison.TweetComparisonId);
            }).Start();

            return inputComparison;
        }
    }
}