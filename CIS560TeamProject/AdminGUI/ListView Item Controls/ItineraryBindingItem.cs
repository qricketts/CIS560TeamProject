using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels; 

namespace AdminGUI
{
    public class ItineraryBindingItem
    {
        private Itinerary _itinerary; 
        public Itinerary Itinerary
        {
            get => _itinerary;
            set => _itinerary = value; 
        }
        private string _name;
        public string Name
        {
            get => _name;
            private set => _name = value;
        }
        private int _totalPlaces;
        public int TotalPlaces
        {
            get => _totalPlaces;
            private set => _totalPlaces = value;
        }

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

        public ItineraryBindingItem(Itinerary i, string personName, DateTime created, DateTime updated)
        {
            Itinerary = i; 
            Name = personName;
            TotalPlaces = i.Places.Count;
            CreatedOn = created;
            UpdatedOn = updated;
        }
    }
}
