using MoviesTime.BusinessLayer.Interface;
using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.BusinessLayer.TheaterManager;

public class TheaterManager :ITheaterManager
{
    private readonly IUnitOfWork _unitOfWork;
    public TheaterManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;   
    }

    public void CreateTheater(Theaters theater)
    {
        _unitOfWork.Theaters.Add(theater);
        _unitOfWork.Save();
    }

    public void CreateTheaterScreen(TheaterScreen theaterScreen)
    {
        _unitOfWork.TheaterScreens.Add(theaterScreen);
        _unitOfWork.Save();
    }

    public List<TheaterScreen> GetTheaterScreensByTheaterID(int theaterID)
    {
        return _unitOfWork.TheaterScreens.GetAll()
                            .Where(x=>x.TheaterID == theaterID
                                    && x.IsActive == true 
                                    && x.IsAvailable == true)
                            .ToList();
    }

    public void CreateGenre(Genres genre)
    {
        _unitOfWork.Genres.Add(genre);
        _unitOfWork.Save();
    }

    public void CreateLanguage(Languages language)
    {
        _unitOfWork.Languages.Add(language);
        _unitOfWork.Save();
    }

    public Genres GetGenreDetailsByID(int genreID)
    {
        return _unitOfWork.Genres.GetFirstOrDefault(x=>x.ID == genreID);
    }

    public Languages GetLanguageDetailsByID(int languageID) 
    {
        return _unitOfWork.Languages.GetFirstOrDefault(x => x.LanguageID == languageID);
    }
}
