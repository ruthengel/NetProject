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
    public class DietServices : IDietServices
    {
        private readonly IDietRepository _dietRepository;

        public DietServices(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }
        public List<Diet> GetList()
        {
            return _dietRepository.GetList();
        }
        public List<Diet> GetByPrice(int price)
        {
            return _dietRepository.GetByPrice(price);
        }
        public int AddDiet(string name, double price, int idcoach)
        {
            return _dietRepository.AddDiet(name, price, idcoach);
        }
        public int ChangeDiet(int id, string name, double price)
        {
            return _dietRepository.ChangeDiet(id, name, price);
        }
        public int RemoveDiet(int id)
        {
            return _dietRepository.RemoveDiet(id);
        }
    }
}
