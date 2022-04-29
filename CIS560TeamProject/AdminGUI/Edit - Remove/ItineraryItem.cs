using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels; 

namespace AdminGUI
{
    public class ItineraryItem
    {
        private Place _place;
        public Place Place
        {
            get => _place;
            private set => _place = value;
        }
        private string _placeName; 
        public string PlaceName
        {
            get => _placeName;
            private set => _placeName = value; 
        }

        private DateTime _dateAdded;
        public DateTime DateAdded
        {
            get => _dateAdded;
            private set => _dateAdded = value;
        }

        public ItineraryItem(Place p)
        {
            Place = p;
            PlaceName = p.Name;
            DateAdded = p.CreatedOn; 
        }

    }
}
