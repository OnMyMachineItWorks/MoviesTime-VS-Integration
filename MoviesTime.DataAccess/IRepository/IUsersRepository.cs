using MoviesTime.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.DataAccess.IRepository
{
    public interface IUsersRepository : IRepository<Users> 
    {
        void Update(Users obj);
    }
}
