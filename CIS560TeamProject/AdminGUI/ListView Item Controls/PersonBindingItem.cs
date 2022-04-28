using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGUI
{
    public class PersonBindingItem
    {
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

        private int _totalItineraries;
        public int TotalItineraries
        {
            get => _totalItineraries;
            private set => _totalItineraries = value;
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

        public PersonBindingItem(string name, string email, int ratings, int itins, DateTime created, DateTime updated)
        {
            Name = name;
            Email = email;
            TotalRatings = ratings;
            TotalItineraries = itins;
            CreatedOn = created;
            UpdatedOn = updated;
        }
    }
}
