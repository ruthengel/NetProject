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
    public class WeightServices : IWeightServices
    {
        private readonly IWeightRepository _weightRepository;

        public WeightServices(IWeightRepository weightRepository)
        {
            _weightRepository = weightRepository;
        }
        public List<Weight> GetById(int id)
        {
            return _weightRepository.GetById(id);
        }
        public int AddWeight(int id, double weight)
        {
            return _weightRepository.AddWeight(id, weight);
        }
    }
}
