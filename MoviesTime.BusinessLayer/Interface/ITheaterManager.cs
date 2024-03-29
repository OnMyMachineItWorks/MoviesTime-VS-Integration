﻿using MoviesTime.Contract.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.BusinessLayer.Interface;

public interface ITheaterManager
{
    void CreateTheater(Theaters theaters);
    void CreateTheaterScreen(TheaterScreen theaterScreen);
    List<TheaterScreen> GetTheaterScreensByTheaterID(int theaterID);
    void CreateGenre(Genres genre);
    void CreateLanguage(Languages language);
    Genres GetGenreDetailsByID(int genreID);
    Languages GetLanguageDetailsByID(int languageID);

    void CreateMovie(Movies Movie, List<int> genreIDs, List<int> languageIDs);
    void UpdateMovie(Movies updatedMovie, List<int> genreIDs, List<int> languageIDs);
}
