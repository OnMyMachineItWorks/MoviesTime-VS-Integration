using Microsoft.EntityFrameworkCore;
using MoviesTime.Contract.Models;

namespace MoviesTime.DataAccess.Database
{
    public class ApplicationDbContext : DbContext
    {
        // manually inherit db context ^ and then add options in v
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //add Dbset of added table models to generate migrations
        public DbSet<Users> Users { get; set; }
        public DbSet<Theaters> Theaters { get; set; }
        public DbSet<TheaterScreen> TheaterScreens { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Languages> Languages { get; set; }
        //public DbSet<Movies> Movies { get; set; }
        //public DbSet<MovieLanguageMapping> MovieLanguageMapping { get; set; }
        //public DbSet<MovieGenreMapping> MovieGenreMapping { get; set; }
        //public DbSet<MovieReview> MovieReview { get; set; }
        //public DbSet<TheaterReview> TheaterReview { get; set; }
        //public DbSet<TheaterScreen> TheaterScreens { get; set; }
        //public DbSet<MovieShows> MovieShows { get; set; }
        //public DbSet<Tickets> Tickets { get; set; }
    }
}
