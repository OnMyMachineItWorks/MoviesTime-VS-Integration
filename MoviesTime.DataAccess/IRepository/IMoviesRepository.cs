using MoviesTime.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.DataAccess.IRepository
{
    public interface IMoviesRepository : IRepository<Movies>
    {
        void Update(Movies obj);
    }
}
