using Microsoft.EntityFrameworkCore;
using MoviesTime.Contract.DbModels;
using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.DataAccess.Repository;

public class MoviesRepository : Repository<Movies>, IMoviesRepository
{
    private readonly ApplicationDbContext _db;
    public MoviesRepository(ApplicationDbContext db) :base(db) 
    {
        _db = db;
    }

    public void Update(Movies obj)
    {
        _db.Update(obj);
    }

    public Movies GetByMovieIdWithMappings(int movieId)
    {
        return _db.Movies
            .Include(m => m.MovieGenreMappings)
            .Include(m => m.MovieLanguageMappings)
            .FirstOrDefault(m => m.MovieID == movieId) 
            ?? throw new ArgumentException("Movie not found."); ;
    }
}
