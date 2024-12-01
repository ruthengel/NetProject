using EasyDiet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Core.Services
{
    public interface ICustomerServices
    {
        public Customer GetById(int id);
        public int AddCustomer(int id, string name, int codeDiet);
        public int ChangeCustomer(int id, string name, int codeDiet, bool status);
        public int RemoveCustomer(int id);
    }
}
