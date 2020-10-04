using Microsoft.EntityFrameworkCore;
using GolfApp.Models;

namespace GolfApp.Data
{
    public class CourseContext : DbContext
    {
        public CourseContext(
            DbContextOptions<CourseContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<Golfer> Golfers { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<HoleScore> HoleScores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Hole>().ToTable("Hole");
            modelBuilder.Entity<Golfer>().ToTable("Golfer");
            modelBuilder.Entity<Round>().ToTable("Round");
            modelBuilder.Entity<HoleScore>().ToTable("HoleScore");

        }

    }
}