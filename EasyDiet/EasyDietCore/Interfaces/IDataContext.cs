﻿using EasyDiet;
using EasyDiet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Core.Interfaces
{
    public interface IDataContext
    {
        public List<Customer> Customers { get; set; }
        public List<Diet> Diets { get; set; }
        public List<Coach> Coaches { get; set; }
        
    }
}
