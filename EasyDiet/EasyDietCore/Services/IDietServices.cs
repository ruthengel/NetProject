using EasyDiet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Core.Services
{
    public interface IDietServices
    {
        public List<Diet> GetList();
        public List<Diet> GetByPrice(int price);
        public int AddDiet(string name, double price, int idcoach);
        public int ChangeDiet(int id, string name, double price);
        public int RemoveDiet(int id);


    }
}
