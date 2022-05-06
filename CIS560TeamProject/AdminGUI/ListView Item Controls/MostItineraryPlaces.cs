using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData; 

namespace AdminGUI
{
    public class MostItineraryPlaces
    {
        //placeid, placename, number of itineraries added to
        private int _placeId; 
        public int PlaceId
        {
            get => _placeId;
            set => _placeId = value; 
        }

        private string _name; 
        public string Name
        {
            get => _name;
            set => _name = value; 
        }
        private int _itineraries; 
        public int Itineraries
        {
            get => _itineraries;
            set => _itineraries = value; 
        }

        private string _category; 
        public string Category
        {
            get => _category;
            set => _category = value; 
        }

        public MostItineraryPlaces(int id, string name, int category, int num)
        {
            PlaceId = id;
            Name = name;
            Category = ((CategorySelected)category).ToString(); 
            Itineraries = num; 
        }
    }
}
