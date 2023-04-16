using MoviesTime.Contract.DbModels;

namespace MoviesTime.BusinessLayer.Interface;

public interface ISharedService
{
    IEnumerable<Users> GetUsersList();
    IEnumerable<Theaters> GetTheatersList();
    Theaters GetTheaterByID(int id);
    TheaterScreen GetTheaterScreenByID(int id);
    List<Genres> GetGenresList();
    List<Languages> GetLanguagesList();
    List<Movies> GetMoviesList();
    Movies GetMovieDetailsByID(int id);

    Movies GetMovieGenresByMovieId(int id);
}
