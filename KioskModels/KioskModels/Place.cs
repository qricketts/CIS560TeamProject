using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskModels.KioskModels
{
    public class Place
    {
        public string Name { get; set; }

        public string Address { get; set; } = null; 

        public string Description { get; set; } = null;

        public object MapLink { get; set; } = null;

        public object Picture { get; set; } = null;

        public Place(string name)
        {
            Name = name; 
        }
    }
}
