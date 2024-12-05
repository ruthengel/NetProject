using EasyDiet;
using EasyDiet.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Core.Interfaces
{
    public interface IDataContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        
    }
}
