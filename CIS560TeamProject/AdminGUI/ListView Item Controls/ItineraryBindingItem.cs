using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using KioskData; 

namespace AdminGUI
{
    public class ItineraryBindingItem
    {
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";
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

        public ItineraryBindingItem(Itinerary i, int personId, DateTime created, DateTime updated)
        {
            Itinerary = i;
            SqlPersonRepository repo = new SqlPersonRepository(connectionString);
            string name = " ";
            foreach (Person p in repo.RetrievePeople())
                if (p.PersonId == personId) name = p.Name; 
            Name = name;
            TotalPlaces = i.Places.Count;
            CreatedOn = created;
            UpdatedOn = updated;
        }
    }
}
