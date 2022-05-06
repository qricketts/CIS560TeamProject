using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGUI
{
    public class PlaceAverageRating
    {
        private int _id;
        public int PlaceId
        {
            get => _id;
            set => _id = value;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        private int _numRatings;
        public int NumRatings
        {
            get => _numRatings;
            set => _numRatings = value;
        }
        private double _avg;
        public double AverageRating
        {
            get => _avg;
            set => _avg = value;
        }
        public PlaceAverageRating(int placeId, string name, int numRatings, double avgRating)
        {
            PlaceId = placeId;
            Name = name;
            NumRatings = numRatings;
            AverageRating = avgRating;
        }
    }
}
