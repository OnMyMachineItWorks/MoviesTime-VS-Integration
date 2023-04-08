using MoviesTime.BusinessLayer.Interface;
using MoviesTime.Contract.Models;
using MoviesTime.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.BusinessLayer.Customer;

public class Customer :ICustomer
{
    private readonly IUnitOfWork _unitOfWork;
    public Customer(IUnitOfWork unitOfWork)
    {
        _unitOfWork =unitOfWork;
    }


}
