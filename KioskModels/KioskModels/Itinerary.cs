using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskModels.KioskModels
{
    public class Itinerary
    {
        public List<Place> Places { get; private set; }

        public Itinerary()
        {
            Places = new List<Place>(); 
        }

        public void Add(Place place)
        {
            foreach(Place p in Places)
            {
                if (place == p) return;
            }
            Places.Add(place); 
        }

        public bool Remove(Place place)
        {
            foreach(Place p in Places)
            {
                if (place == p)
                {
                    Places.Remove(place);
                    return true;
                }
            }
            return false; 
        }
    }
}
