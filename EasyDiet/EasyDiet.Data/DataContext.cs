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
    public class DataContext : DbContext, IDataContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>()
                .HasKey(c => c.Id); // הגדרה כמפתח ראשי

            modelBuilder.Entity<Coach>()
                .Property(c => c.Id)
                .ValueGeneratedNever(); // הערך לא נוצר אוטומטית
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>()
        //        .HasOne(c => c.MyDiet) 
        //        .WithOne()             
        //        .HasForeignKey<Diet>(d => d.Code); 
        //}
    }
}
