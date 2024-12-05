using EasyDiet;
using EasyDiet.Core.Interfaces;
using EasyDiet.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EasyDiet.Data
{
    public class DataContext : DbContext,IDataContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Coach> Coaches { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db");
        }

    }
}
