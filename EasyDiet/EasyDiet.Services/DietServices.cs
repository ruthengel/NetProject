using EasyDiet.Core.Models;
using EasyDiet.Core.Repositories;
using EasyDiet.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Services
{
    public class DietServices:IDietServices
    {
        private readonly IDietRepository _dietRepository;

        public DietServices(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }
        public List<Diet> GetAll()
        {
            return _dietRepository.GetList();
        }
    }
}
