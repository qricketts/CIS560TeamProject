using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class ItineraryPlace
    {
        private int _id; 
        public int ItineraryPlaceId
        {
            get => _id;
            set => _id = value; 
        }
        private Place _place;
        public Place Place
        {
            get => _place;
            private set => _place = value; 
        }

        private Itinerary _itinerary;
        public Itinerary Itinerary
        {
            get => _itinerary;
            private set => _itinerary = value;
        }

        public ItineraryPlace(int id, Itinerary i, Place p) 
        {
            ItineraryPlaceId = id; 
            Itinerary = i;
            Place = p; 
        }
    }
}
