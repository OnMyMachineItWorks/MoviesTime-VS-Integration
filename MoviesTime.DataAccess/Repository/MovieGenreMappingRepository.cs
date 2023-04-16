using MoviesTime.Contract.DbModels;
using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.DataAccess.Repository;

public class MovieGenreMappingRepository : Repository<MovieGenreMapping>, IMovieGenreMapping
{
    private readonly ApplicationDbContext _db;

    public MovieGenreMappingRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }


}
