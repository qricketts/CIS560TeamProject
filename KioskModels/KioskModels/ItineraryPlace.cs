using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class ItineraryPlace
    {
        public Place Place { get; private set; }
        
        public Itinerary Itinerary { get; private set; }

        public ItineraryPlace(Itinerary i, Place p) 
        {
            Itinerary = i;
            Place = p; 
        }
    }
}
