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
    public class CoachRepository : ICoachRepository
    {
        private readonly IDataContext _context;

        public CoachRepository(IDataContext context)
        {
            _context = context;
        }

        public List<Coach> GetList()
        {
            return _context.Coaches.ToList();
        }
        public Coach GetById(int id)
        {
            return _context.Coaches.FirstOrDefault(c => c.Id == id);
        }
        public void AddCoach(int id, string name, string city, string phone)
        {
            _context.Coaches.Add(new Coach(id, name, city, phone));
        }
        public int ChangeCoach(int id, string Name, string city, string phone, bool status)
        {

            Coach coach = _context.Coaches.FirstOrDefault(c => c.Id.Equals(id));
            if (coach is null)
                return -1;
            coach.City = city;
            coach.Phone = phone;
            coach.Name = Name;
            coach.Status = status;
            return 1;
        }
        public int RemoveCoach(int id)
        {

            Coach coach = _context.Coaches.ToList().Find(c => c.Id.Equals(id));
            if (coach is null)
                return -1;
            coach.Status = false;
            coach.MyDiets.ForEach(d => d.Status = false);
            return 1;
        }
    }
}
