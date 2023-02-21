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
    public class TheatersRepository : Repository<Theaters>, ITheatersRepository
    {
        private readonly ApplicationDbContext _db;
        
        public TheatersRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

        public void Update(Theaters obj)
        {
            throw new NotImplementedException();
        }
    }
}
