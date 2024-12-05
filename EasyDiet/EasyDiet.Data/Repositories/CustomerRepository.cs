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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }
        public int AddCustomer(int id, string name, int codeDiet)
        {
            Diet diet = _context.Diets.FirstOrDefault(d => d.Code == codeDiet);
            if (diet is null)
                return -1;
            else if (!diet.Status)
                return -1;
            Coach coach = _context.Coaches.FirstOrDefault(c => c.Id == diet.Coach);
            if (coach is null)
                return -1;
            Customer customer = new Customer(id, name, diet.Code);
            _context.Customers.Add(customer);
            _context.Coaches.ToList().Find(c => coach.Id == c.Id).MyCustomers.Add(customer);
            _context.SaveChanges();
            return 1;

        }
        public int ChangeCustomer(int id, string name, int codeDiet, bool status)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            Diet diet = _context.Diets.FirstOrDefault(d => d.Code == codeDiet);
            if (customer is not null && diet is not null && diet.Status)
            {

                customer.Id = id;
                customer.Name = name;
                customer.Status = status;
                diet.Code = codeDiet;
                //Coach coach = _context.Coaches.FirstOrDefault(c => c.Id == diet.Coach);
                //if (diet.Coach != customer.MyDiet.Coach)
                Coach coach = _context.Coaches.FirstOrDefault(c => c.Id == diet.Coach);
                if (coach is null)
                    return -1;
                coach.MyCustomers.Remove(customer);
                coach.MyCustomers.Add(customer);
                customer.MyDiet = diet.Code;
                _context.SaveChanges();
                return 1;
            }
            else
                return -1;
        }
        public int RemoveCustomer(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer is null)
                return -1;
            Diet diet = _context.Diets.FirstOrDefault(d => d.Code == customer.MyDiet);
            if (customer is null)
                return -1;
            Coach coach = _context.Coaches.FirstOrDefault(c => c.Id == diet.Coach);
            if (coach is null)
                return -1;
            customer.Status = false;
            coach.MyCustomers.Remove(customer);
            _context.SaveChanges();
            return 1;
        }
    }
}
