using Microsoft.EntityFrameworkCore;
using MoodBasedPlaylistApi.Models;

namespace MoodBasedPlaylistApi.Data
{
    public class MoodBasedPlaylistDbContext : DbContext
    {
        public MoodBasedPlaylistDbContext(DbContextOptions<MoodBasedPlaylistDbContext> options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().ToTable("Songs");
        }
    }
}
