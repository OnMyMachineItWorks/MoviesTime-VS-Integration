using MoviesTime.BusinessLayer.Interface;
using MoviesTime.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.BusinessLayer.TheaterManager
{
    public class TheaterManager :ITheaterManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public TheaterManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        
    }
}
