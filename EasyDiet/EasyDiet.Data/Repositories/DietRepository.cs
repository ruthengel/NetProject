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
    public class DietRepository : IDietRepository
    {
        private readonly DataContext _context;

        public DietRepository(DataContext context)
        {
            _context = context;
        }

        public List<Diet> GetList()
        {
            return _context.Diets.ToList();
        }
        public List<Diet> GetByPrice(int price)
        {
            return _context.Diets.ToList().FindAll(d => d.Price <= price);
        }
        public int AddDiet(string name, double price, int idcoach)
        {
            Coach coach = _context.Coaches.FirstOrDefault(c => c.Id == idcoach);
            if (coach is null)
                return -1;
            if (coach.Status)
            {
                Diet diet = new Diet(name, price, idcoach);
                coach.MyDiets.Add(diet);
                _context.Diets.Add(diet);
            }
            _context.SaveChanges();
            return 1;
        }
        public int ChangeDiet(int id, string name, double price)
        {
            Diet diet = _context.Diets.FirstOrDefault(d => d.Code == id);
            if (diet is null)
                return -1;
            if (diet.Status)
            {
                diet.Name = name;
                diet.Price = price;
            }
            _context.SaveChanges();
            return 1;
        }
        public int RemoveDiet(int id)
        {
            Diet d = _context.Diets.ToList().Find(d => d.Code == id);
            if (d is null)
                return -1;
            d.Status = false;
            _context.SaveChanges();
            return 1;
        }
    }
}
