using MoviesTime.Contract.DbModels;
using MoviesTime.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.DataAccess.IRepository
{
    public interface IMovieGenreMapping :IRepository<MovieGenreMapping>
    {
    }
}
