using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using poptwit.Models;

namespace poptwit
{
    public static class Settings
    {
        public static IConfiguration Configuration { get; set; }
        public static string PopDbConnection { get { return Configuration[nameof(PopDbConnection)]; } }
        public static string TwitterKey { get { return Configuration[nameof(TwitterKey)]; } }
        public static string TwitterSecret { get { return Configuration[nameof(TwitterSecret)]; } }
        public static string TwitterAccessToken { get { return Configuration[nameof(TwitterAccessToken)]; } }
        public static string TwitterAccessTokenSecret { get { return Configuration[nameof(TwitterAccessTokenSecret)]; } }
        public static string TwitterPremiumSearchBaseAPI { get { return Configuration[nameof(TwitterPremiumSearchBaseAPI)]; } }
    }

    public class PopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TweetComparison> Comparisons { get; set; }

        public PopContext(DbContextOptions<PopContext> options) : base(options)
        {
        }
    }
    
    public class PopContextSingleton : DbContext
    {
        private string _dbPath = Settings.PopDbConnection;

        public DbSet<User> Users { get; set; }
        public DbSet<TweetComparison> Comparisons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_dbPath);
        }
    }
}