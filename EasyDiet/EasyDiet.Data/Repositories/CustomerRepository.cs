using EasyDiet.Core.Interfaces;
using EasyDiet.Core.Models;
using EasyDiet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Data.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly IDataContext _context;

        public CustomerRepository(IDataContext context)
        {
            _context = context;
        }

        public List<Customer> GetList()
        {
            return _context.Customers;
        }
    }
}
