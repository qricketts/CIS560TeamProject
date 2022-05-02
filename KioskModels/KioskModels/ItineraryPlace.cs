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
        private int  _placeId;
        public int PlaceId
        {
            get => _placeId;
            private set => _placeId = value; 
        }

        private int _itineraryId;
        public int ItineraryId
        {
            get => _itineraryId;
            private set => _itineraryId = value;
        }

        public ItineraryPlace(int id, int i, int p) 
        {
            ItineraryPlaceId = id; 
            ItineraryId = i;
            PlaceId = p; 
        }
    }
}
