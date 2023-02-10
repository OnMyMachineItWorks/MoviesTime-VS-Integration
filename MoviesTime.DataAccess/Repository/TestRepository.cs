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
    public class TestRepository : Repository<TestModel>, ITestInterface
    {
        private ApplicationDbContext _db;
        public TestRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(TestModel obj)
        {
            _db.TestTable.Update(obj);
        }
    }
}
