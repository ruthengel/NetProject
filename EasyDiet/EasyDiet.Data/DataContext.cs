using EasyDiet;
using EasyDiet.Core.Interfaces;
using EasyDiet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EasyDiet.Data
{
    public class DataContext : IDataContext
    {

        public List<Customer> Customers { get; set; }
        public List<Diet> Diets { get; set; }
        public List<Coach> Coaches { get; set; }


        public DataContext()
        {
            Customers = new List<Customer>();
            Diets = new List<Diet>();
            Coaches = new List<Coach>();
            Coaches.Add(new Coach(1, "ijh", "bbh", "0556894"));
            Customers.Add(new Customer(1, "gfg", new Diet("ff", 45, 1)));
        }
    }
}
