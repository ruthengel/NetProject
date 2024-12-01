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
        public List<Coach> GetList()
        {
            return _coachRepository.GetList();
        }
        public Coach GetById(int id)
        {
            return _coachRepository.GetById(id);
        }
        public void AddCoach(int id, string name, string city, string phone)
        {
            _coachRepository.AddCoach(id, name, city, phone);
        }
        public int ChangeCoach(int id, string Name, string city, string phone, bool status)
        {
            return _coachRepository.ChangeCoach(id, Name, city, phone, status);
        }
        public int RemoveCoach(int id)
        {
            return _coachRepository.RemoveCoach(id);
        }
    }
}
