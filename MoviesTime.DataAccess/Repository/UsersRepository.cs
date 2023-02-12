using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.Database;
using MoviesTime.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.DataAccess.Repository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        private readonly ApplicationDbContext _db;

        public UsersRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Users user)
        {
            _db.Update(user);
        }
    }
}
