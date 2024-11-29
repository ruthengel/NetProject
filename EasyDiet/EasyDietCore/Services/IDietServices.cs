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
        public List<Diet> GetAll();
    }
}
