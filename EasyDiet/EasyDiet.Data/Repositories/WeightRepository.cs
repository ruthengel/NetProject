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
    public class WeightRepository : IWeightRepository
    {
        private readonly DataContext _context;

        public WeightRepository(DataContext context)
        {
            _context = context;
        }
        public List<Weight> GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id).MyWeigths;
        }
        public int AddWeight(int id, double weight)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer is null)
                return -1;
            customer.MyWeigths.Add(new Weight(DateTime.Now, weight));
            _context.SaveChanges();
            return 1;
        }
    }
}
