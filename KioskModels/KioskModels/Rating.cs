using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class Rating
    {
        private int _ratingId; 
        public int RatingId
        {
            get => _ratingId;
            set => _ratingId = value; 
        }
        private int _rate; 
        public int Rate
        {
            get => _rate;
            set => _rate = value; 
        }
        private int _placeId; 
        public int PlaceId
        {
            get => _placeId;
            set => _placeId = value; 
        }
        private int _personId; 
        public int PersonId
        {
            get => _personId;
            set => _personId = value; 
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
            set => _updatedOn = value; 
        }

        public Rating(int id, int rating, int place, int person)
        {
            RatingId = id; 
            Rate = rating;
            PlaceId = place;
            PersonId = person;
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }
    }
}
