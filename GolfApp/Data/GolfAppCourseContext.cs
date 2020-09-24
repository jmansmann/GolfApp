using Microsoft.EntityFrameworkCore;

namespace GolfApp.Data
{
    public class GolfAppCourseContext : DbContext
    {
        public GolfAppCourseContext (
            DbContextOptions<GolfAppCourseContext> options)
            : base(options)
        {
        }

        public DbSet<GolfApp.Models.Course> Course { get; set; }
        public DbSet<GolfApp.Models.Location> Location { get; set; }
        public DbSet<GolfApp.Models.Hole> Hole { get; set; }
        //public DbSet<GolfApp.Models.Golfer> Golfer { get; set; }

    }
}