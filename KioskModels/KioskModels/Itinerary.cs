using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class Itinerary
    {
        private int _id;
        public int ItineraryId
        {
            get => _id;
            set => _id = value; 
        }
        public List<Place> Places { get; private set; } = new List<Place>();

        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get => _createdOn;
            private set => _createdOn = value;
        }

        private DateTime _updatedOn;
        public DateTime UpdatedOn
        {
            get => _updatedOn;
            private set => _updatedOn = value;
        }


        public Itinerary(int id)
        {
            ItineraryId = id; 
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
