using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using signalR.Models;

namespace signalR.Data.Abstract
{
    public class LiveGameContext : DbContext
    {
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Match> Matches { get; set; }

        public LiveGameContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Match>()
                .ToTable("Match");
            modelBuilder.Entity<Feed>()
                .ToTable("Feed");
            modelBuilder.Entity<Feed>()
                .Property(f => f.MatchId)
                .IsRequired();
        }

    }
}