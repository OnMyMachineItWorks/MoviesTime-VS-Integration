using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Users = new UsersRepository(_db);
            Theaters = new TheatersRepository(_db);
        }

        public IUsersRepository Users { get; private set; }
        public ITheatersRepository Theaters { get; private set; }


        // Save method Implementation
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
