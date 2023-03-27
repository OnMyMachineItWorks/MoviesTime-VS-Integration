using MoviesTime.BusinessLayer.Interface;
using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.BusinessLayer.TheaterManager
{
    public class TheaterManager :ITheaterManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public TheaterManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public Theaters CreateTheater(Theaters theater)
        {
            _unitOfWork.Theaters.Add(theater);
            return null;
        }

        public TheaterScreen CreateTheaterScreen(TheaterScreen theaterScreen)
        {
            _unitOfWork.TheaterScreens.Add(theaterScreen);
            _unitOfWork.Save();
            return null;
        }

        public List<TheaterScreen> GetTheaterScreensByTheaterID(int theaterID)
        {
            return _unitOfWork.TheaterScreens.GetAll()
                                .Where(x=>x.TheaterID == theaterID
                                        && x.IsActive == true 
                                        && x.IsAvailable == true)
                                .ToList();
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
}
