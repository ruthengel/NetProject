﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDiet.Core.Repositories
{
    public interface IWeightRepository
    {
        public int GetById(int id);
        public int AddWeight(int id, double weight);
    }
}
