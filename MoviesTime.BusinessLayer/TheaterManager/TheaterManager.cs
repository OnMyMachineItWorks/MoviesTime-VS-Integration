using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviesTime.BusinessLayer.Interface;
using MoviesTime.BusinessLayer.Shared;
using MoviesTime.Contract.DbModels;
using MoviesTime.DataAccess.IRepository;

namespace MoviesTime.BusinessLayer.TheaterManager;

public class TheaterManager : ITheaterManager
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
                            .Where(x => x.TheaterID == theaterID
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
        return _unitOfWork.Genres.GetFirstOrDefault(x => x.ID == genreID);
    }

    public Languages GetLanguageDetailsByID(int languageID)
    {
        return _unitOfWork.Languages.GetFirstOrDefault(x => x.LanguageID == languageID);
    }

    public void CreateMovie(Movies movie, List<int> genreIDs, List<int> languageIDs)
    {
        if (movie.MovieTitle.IsNullOrEmpty())
            movie.MovieTitle = "TestGenreLanguage";

        genreIDs?.ForEach(genreID =>
                    {
                        var movieGenre = new MovieGenreMapping { MovieID = movie.MovieID, GenreID = genreID };
                        movie.MovieGenreMappings.Add(movieGenre);
                    });
        languageIDs?.ForEach(languageID =>
                    {
                        var movieLanguage = new MovieLanguageMapping { MovieID = movie.MovieID, LanguageID = languageID };
                        movie.MovieLanguageMappings.Add(movieLanguage);
                    });
        _unitOfWork.Movies.Add(movie);
        _unitOfWork.Save();
    }

    public void UpdateMovie(Movies updatedMovie, List<int> genreIDs, List<int> languageIDs)
    {
        //Get Movie details from DB
        Movies movie = _unitOfWork.Movies.GetByMovieIdWithMappings(updatedMovie.MovieID);

        // Update genre associations
        var existingGenreIds = movie.MovieGenreMappings.Select(g => g.GenreID).ToList();
        if (genreIDs != null)
        {
            var addedGenres = genreIDs.Except(existingGenreIds);
            var removedGenres = existingGenreIds.Except(genreIDs);
            
            foreach (var genreId in addedGenres)
            {
                var genreMapping = new MovieGenreMapping { GenreID = genreId };
                movie.MovieGenreMappings.Add(genreMapping);
            }

            foreach (var genreId in removedGenres)
            {
                var genreMapping = movie.MovieGenreMappings.FirstOrDefault(g => g.GenreID == genreId);
                if (genreMapping != null)
                {
                    movie.MovieGenreMappings.Remove(genreMapping);
                }
            }
        }
        else  // when all genre mapping are removed from movie. 
        {
            foreach (var genreId in existingGenreIds)
            {
                var genreMapping = movie.MovieGenreMappings.FirstOrDefault(g => g.GenreID == genreId);
                if (genreMapping != null)
                {
                    movie.MovieGenreMappings.Remove(genreMapping);
                }
            }
        }

        // Update language associations
        var existingLanguageIds = movie.MovieLanguageMappings.Select(g => g.LanguageID).ToList();
        if (languageIDs != null)
        {
            var addedLanguages = languageIDs.Except(existingLanguageIds);
            var removedLanguages = existingLanguageIds.Except(languageIDs);

            foreach (var languageId in addedLanguages)
            {
                var languageMapping = new MovieLanguageMapping { LanguageID = languageId };
                movie.MovieLanguageMappings.Add(languageMapping);
            }

            foreach (var languageId in removedLanguages)
            {
                var languageMapping = movie.MovieLanguageMappings.FirstOrDefault(g => g.LanguageID == languageId);
                if (languageMapping != null)
                {
                    movie.MovieLanguageMappings.Remove(languageMapping);
                }
            }
        }
        else // when all languages mapping are removed from movie.
        {
            foreach (var languageId in existingLanguageIds)
            {
                var languageMapping = movie.MovieLanguageMappings.FirstOrDefault(g => g.LanguageID == languageId);
                if (languageMapping != null)
                {
                    movie.MovieLanguageMappings.Remove(languageMapping);
                }
            }
        }

        //_unitOfWork.Movies.Update(movie);
        _unitOfWork.Save();

    }
}
