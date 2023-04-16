using MoviesTime.Contract.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.DataAccess.IRepository;

public interface IUnitOfWork
{
    IUsersRepository Users { get; }
    ITheatersRepository Theaters { get; }
    ITheaterScreensRepository TheaterScreens { get; }
    IGenreRepository Genres { get; }
    ILanguageRepository Languages { get; }
    IMoviesRepository Movies { get; }

    void Save();

    Movies GetMovieGenresByMovieId(int id);
    Movies GetMovieLanguagesByMovieId(int id);
}
