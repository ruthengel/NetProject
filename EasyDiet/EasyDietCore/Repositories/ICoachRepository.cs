using EasyDiet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Core.Repositories
{
    public interface ICoachRepository
    {
        public List<Coach> GetList();
        public Coach GetById(int id);
        public void AddCoach(int id, string name, string city, string phone);
        public int ChangeCoach(int id, string Name, string city, string phone, bool status);
        public int RemoveCoach(int id);

    }
}
