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
        private readonly IDataContext _context;

        public DietRepository(IDataContext context)
        {
            _context = context;
        }

        public List<Diet> GetList()
        {
            return _context.Diets;
        }
        public List<Diet> GetByPrice(int price)
        {
            return _context.Diets.FindAll(d => d.Price <= price);
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
            return 1;
        }
        public int RemoveDiet(int id)
        {

            Diet d = _context.Diets.Find(d => d.Code == id);
            if (d is null)
                return -1;
            d.Status = false;
            return 1;
        }
    }
}
