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
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }
        public int AddCustomer(int id, string name, int codeDiet)
        {
            return _customerRepository.AddCustomer(id, name, codeDiet);
        }
        public int ChangeCustomer(int id, string name, int codeDiet, bool status)
        {
            return _customerRepository.ChangeCustomer(id, name, codeDiet, status);
        }
        public int RemoveCustomer(int id)
        {
            return _customerRepository.RemoveCustomer(id);
        }
    }
}
