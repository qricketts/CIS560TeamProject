﻿using System;
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
        private Place _place; 
        public Place Place
        {
            get => _place;
            set => _place = value; 
        }
        private Person _person; 
        public Person Person
        {
            get => _person;
            set => _person = value; 
        }
        private DateTime _createdOn; 
        public DateTime CreatedOn
        {
            get => _createdOn;
            private set => _createdOn = value; 
        }

        public Rating(int id, int rating, Place place, Person person)
        {
            RatingId = id; 
            Rate = rating;
            Place = place;
            Person = person; 
        }
    }
}
