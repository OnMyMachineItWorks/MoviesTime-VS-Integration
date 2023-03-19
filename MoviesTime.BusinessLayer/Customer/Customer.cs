using MoviesTime.BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.BusinessLayer.Customer
{
    public class Customer :ICustomer
    {
        public int GetUsersCount() 
        {
            return 10;
        }
    }
}
