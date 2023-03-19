using MoviesTime.BusinessLayer.Interface;
using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.BusinessLayer.Shared
{
    public class SharedService : ISharedService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SharedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Users> GetUsersList()
        {
            return _unitOfWork.Users.GetAll();
        }

        public IEnumerable<Theaters> GetTheatersList()
        {
            return _unitOfWork.Theaters.GetAll();
        }

        public Theaters GetTheaterByID(int id) 
        {
            return _unitOfWork.Theaters.GetFirstOrDefault(x => x.TheaterID == id);
        }

    }
}
