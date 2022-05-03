using KioskData.KioskModels;
using System;

namespace AdminGUI
{
    public class PersonBindingItem
    {
        private Person _person; 
        public Person Person
        {
            get => _person;
            private set => _person = value; 
        }
        private string _name;
        public string Name
        {
            get => _name;
            private set => _name = value;
        }
        private string _email;
        public string Email
        {
            get => _email;
            private set => _email = value;
        }
        private int _totalRatings;
        public int TotalRatings
        {
            get => _totalRatings;
            private set => _totalRatings = value;
        }

        private double _averageRating;
        public double AverageRating
        {
            get => _averageRating;
            private set => _averageRating = value;
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

        public PersonBindingItem(Person person, int numRatings, double avg, DateTime created, DateTime updated)
        {
            Person = person; 
            Name = person.Name;
            Email = person.Email; 
            TotalRatings = numRatings;
            AverageRating = avg;
            CreatedOn = created;
            UpdatedOn = updated;
        }
    }
}
