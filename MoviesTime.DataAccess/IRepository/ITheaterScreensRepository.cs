using MoviesTime.Contract.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.DataAccess.IRepository 
{
    public interface ITheaterScreensRepository : IRepository<TheaterScreen>
    {
        void Update(TheaterScreen obj);
    }
}
