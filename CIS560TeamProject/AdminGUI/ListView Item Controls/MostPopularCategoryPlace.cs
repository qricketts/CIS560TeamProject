using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData; 

namespace AdminGUI
{
    public class MostPopularCategoryPlace
    {
        private string _name; 
        public string Name
        {
            get => _name;
            set => _name = value; 
        }

        private string _category; 
        public string Category
        {
            get => _category;
            set => _category = value; 
        }

        private int _itineraries; 
        public int Itineraries
        {
            get => _itineraries;
            set => _itineraries = value; 
        }

        public MostPopularCategoryPlace(string n, string c, int i)
        {
            Name = n;
            Category = c; 
            Itineraries = i; 
        }
    }
}
