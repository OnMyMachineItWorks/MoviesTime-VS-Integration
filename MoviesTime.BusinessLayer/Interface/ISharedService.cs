using MoviesTime.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.BusinessLayer.Interface
{
    public interface ISharedService
    {
        IEnumerable<Users> GetUsersList();
        IEnumerable<Theaters> GetTheatersList();
        Theaters GetTheaterByID(int id);
    }
}
