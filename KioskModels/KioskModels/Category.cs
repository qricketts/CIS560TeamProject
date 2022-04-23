﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskModels.KioskModels
{
    public class Category
    {
        public string Name { get; private set; }

        public List<Place> Places;

        public Category(string name)
        {
            Name = name; 
        }
    }
}
