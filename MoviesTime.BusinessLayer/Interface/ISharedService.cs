using MoviesTime.Contract.Models;

namespace MoviesTime.BusinessLayer.Interface
{
    public interface ISharedService
    {
        IEnumerable<Users> GetUsersList();
        IEnumerable<Theaters> GetTheatersList();
        Theaters GetTheaterByID(int id);
        TheaterScreen GetTheaterScreenByID(int id);
        List<Genres> GetGenresList();
        List<Languages> GetLanguagesList();
    }
}
