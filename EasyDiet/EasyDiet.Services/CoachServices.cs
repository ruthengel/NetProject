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
    public class CoachServices :ICoachServices
    {
        private readonly ICoachRepository _coachRepository;

        public CoachServices(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }
        public List<Coach> GetAll()
        {
            return _coachRepository.GetList();
        }

    }
}
