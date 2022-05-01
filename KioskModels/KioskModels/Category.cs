using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class Category
    {
        private int _categoryId; 
        public int CategoryId
        {
            get => _categoryId;
            set => _categoryId = value; 
        }

        private string _name; 
        public string Name
        {
            get => _name;
            set => _name = value; 
        }

        public List<Place> Places { get; private set; }

        public Category(int id, string name)
        {
            CategoryId = id; 
            Name = name; 
        }

        public void AddPlace(Place p)
        {
            if (Places.Contains(p)) return;
            Places.Add(p); 
        }
        public void RemovePlace(Place p)
        {
            if (!Places.Contains(p)) return;
            Places.Remove(p); 
        }
    }
}
