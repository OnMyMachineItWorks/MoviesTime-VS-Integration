using MoviesTime.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.BusinessLayer.Interface
{
    public interface ITheaterManager
    {
        List<TheaterScreen> GetTheaterScreensByTheaterID(int theaterID);
        Theaters CreateTheater(Theaters theaters);
        TheaterScreen CreateTheaterScreen(TheaterScreen theaterScreen);
        Genres GetGenreDetailsByID(int genreID);
        Languages GetLanguageDetailsByID(int languageID);
    }
}
