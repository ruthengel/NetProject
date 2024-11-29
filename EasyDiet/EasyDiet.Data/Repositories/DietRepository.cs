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
    }
}
