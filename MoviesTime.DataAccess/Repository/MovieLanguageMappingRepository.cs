using MoviesTime.Contract.DbModels;
using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.DataAccess.Repository;

public class MovieLanguageMappingRepository : Repository<MovieLanguageMapping>, IMovieLanguageMapping
{
    private readonly ApplicationDbContext _db;

    public MovieLanguageMappingRepository(ApplicationDbContext db) :base(db)
    {
        _db = db;
    }
}
