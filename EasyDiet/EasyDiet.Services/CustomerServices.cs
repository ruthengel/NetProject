using EasyDiet.Core.Repositories;
using EasyDiet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyDiet.Core.Services;

namespace EasyDiet.Services
{
    public class CustomerServices:ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public List<Customer> GetAll()
        {
            return _customerRepository.GetList();
        }
    }
}
