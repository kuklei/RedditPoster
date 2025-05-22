using Microsoft.EntityFrameworkCore;
using RedditPoster.Models;

namespace RedditPoster.Data
{
    public class HarmonyDbContext : DbContext
    {
        public HarmonyDbContext(DbContextOptions<HarmonyDbContext> options) : base(options) { }

        public DbSet<Message> Messages => Set<Message>();
        public DbSet<MessageTarget> MessageTargets => Set<MessageTarget>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // No relationship configuration needed since navigation is removed
        }
    }
}
