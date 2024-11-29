using EasyDiet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Core.Repositories
{
    public interface ICustomerRepository
    {
        public List<Customer> GetList();
    }
}
