using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.DataAccess.Repository {
    public class TheaterScreensRepository : Repository<TheaterScreen>, ITheaterScreensRepository 
    {
        public readonly ApplicationDbContext _db;
        public TheaterScreensRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TheaterScreen theaterScreen) 
        {
            _db.Update(theaterScreen);
        }
    }
}
