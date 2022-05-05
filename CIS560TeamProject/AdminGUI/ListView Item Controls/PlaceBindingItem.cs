using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels; 

namespace AdminGUI
{
    public class PlaceBindingItem
    {
        private Place _place; 
        public Place Place
        {
            get => _place;
            private set => _place = value; 
        }

        private string _name; 
        public string Name
        {
            get => _name;
            private set => _name = value;
        }
        private string _address;
        public string Address
        {
            get => _address;
            private set => _address = value;
        }
        private double _avgRating;
        public double AverageRating
        {
            get => _avgRating;
            private set => _avgRating = value;
        }

        private int _itineraryCount;
        public int ItineraryCount
        {
            get => _itineraryCount;
            private set => _itineraryCount = value;
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

        public PlaceBindingItem(Place place, int numRatings, int sumRatings, int count, DateTime updated)
        {
            Place = place;
            Name = place.Name;
            Address = place.Address;
            AverageRating = (double)sumRatings / numRatings;
            if (numRatings == 0) AverageRating = 0; 
            ItineraryCount = count;
            CreatedOn = place.CreatedOn; 
            UpdatedOn = updated; 
        }
    }
}
