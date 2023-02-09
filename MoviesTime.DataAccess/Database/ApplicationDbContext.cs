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

        public DbSet<TestModel> TestTable { get; set; } 

    }
}
