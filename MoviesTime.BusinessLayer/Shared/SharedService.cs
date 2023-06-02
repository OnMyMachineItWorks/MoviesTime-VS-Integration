using MoviesTime.BusinessLayer.Interface;
using MoviesTime.Contract.DbModels;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.BusinessLayer.Shared;

public class SharedService : ISharedService
{
    private readonly IUnitOfWork _unitOfWork;
    public SharedService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Users> GetUsersList()
    {
        return _unitOfWork.Users.GetAll();
    }

    public IEnumerable<Theaters> GetTheatersList()
    {
        return _unitOfWork.Theaters.GetAll();
    }

    public Theaters GetTheaterByID(int id) 
    {
        return _unitOfWork.Theaters.GetFirstOrDefault(x => x.TheaterID == id);
    }

    public TheaterScreen GetTheaterScreenByID(int id)
    {
        return _unitOfWork.TheaterScreens.GetFirstOrDefault(x => x.ScreenID == id);
    }

    public List<Genres> GetGenresList()
    {
        return _unitOfWork.Genres.GetAll()
                                 .Where(genre => genre.IsActive == true)
                                 .ToList();
    }

    public List<Languages> GetLanguagesList()
    {
        return _unitOfWork.Languages.GetAll()
                                    .Where (language => language.IsActive == true)
                                    .ToList();
    }

    public List<Movies> GetMoviesList()
    {
        return _unitOfWork.Movies.GetAll().ToList();
    }

    public Movies GetMovieDetailsByID(int id) 
    {
        return _unitOfWork.Movies.GetFirstOrDefault(x => x.MovieID == id);
    }
    //public MovieGenreMapping GetMoviesByID(int id) 
    //{
    //    return _unitOfWork.Movies.GetFirstOrDefault(x => x.MovieID == id);
    //}
    public Movies GetMoviesWithMappings(int id) 
    {
        return _unitOfWork.Movies.GetByMovieIdWithMappings(id);
    }
}
