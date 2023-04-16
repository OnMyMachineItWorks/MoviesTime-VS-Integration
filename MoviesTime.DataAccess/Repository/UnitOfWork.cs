using Microsoft.EntityFrameworkCore;
using MoviesTime.Contract.DbModels;
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
            TheaterScreens = new TheaterScreensRepository(_db);
            Genres = new GenreRepository(_db);
            Languages = new LanguageRepository(_db);
            Movies = new MoviesRepository(_db);
            MovieGenreMapping = new MovieGenreMappingRepository(_db);
        }

        public IUsersRepository Users { get; private set; }
        public ITheatersRepository Theaters { get; private set; }
        public ITheaterScreensRepository TheaterScreens { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public ILanguageRepository Languages { get; private set; }
        public IMoviesRepository Movies { get; private set; }
        public IMovieGenreMapping MovieGenreMapping { get; private set; }

        // Save method Implementation
        public void Save()
        {
            _db.SaveChanges();
        }

        // Using MovieID, Returns a Movie and all genres related to that movie.
        public Movies GetMovieGenresByMovieId(int id) 
        {
            return _db.Movies.Include(m => m.MovieGenreMappings !)
                            .ThenInclude(gm => gm.Genre)
                            .FirstOrDefault(m => m.MovieID == id);
        }

        // Using MovieID, Returns a Movie and all Languages related to that movie.
        public Movies GetMovieLanguagesByMovieId(int id) 
        {
            return _db.Movies.Include(m => m.MovieLanguageMappings !)
                            .ThenInclude(mlm => mlm.Languages)
                            .FirstOrDefault(m => m.MovieID == id);
        } 

    }
}
