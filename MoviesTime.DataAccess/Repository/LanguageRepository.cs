using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.DataAccess.Repository;

public class LanguageRepository :Repository<Languages>, ILanguageRepository
{
    private readonly ApplicationDbContext _db;
    public LanguageRepository(ApplicationDbContext db) : base (db)
    {
        _db = db;
    }

    public void Update(Languages language)
    {
        _db.Update(language);
    }
}
