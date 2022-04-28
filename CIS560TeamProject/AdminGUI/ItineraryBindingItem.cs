using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGUI
{
    public class ItineraryBindingItem
    {
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

        public ItineraryBindingItem(string personName, int places, DateTime created, DateTime updated)
        {
            Name = personName;
            TotalPlaces = places;
            CreatedOn = created;
            UpdatedOn = updated;
        }
    }
}
