using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using poptwit.Models;

namespace poptwit
{
    public static class Settings
    {
        private static IConfiguration _configuration;

        public static string PopDbConnection { get { return _configuration["PopDBConnection"]; } }

        static Settings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
           _configuration = builder.Build(); 
        }
    }

    public class PopContext : DbContext
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