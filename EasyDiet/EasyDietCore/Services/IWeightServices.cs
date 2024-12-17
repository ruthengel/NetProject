using EasyDiet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Core.Services
{
    public interface IWeightServices
    {
        public List<Weight> GetById(int id);
        public int AddWeight(int id, double weight);
    }
}
