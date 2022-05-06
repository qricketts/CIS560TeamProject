using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class Itinerary
    {
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";

        private int _itineraryId;
        public int ItineraryId
        {
            get => _itineraryId;
            set => _itineraryId = value; 
        }
        private int _personId;
        public int PersonId
        {
            get => _personId;
            set => _personId = value;
        }
        public List<Place> Places { get; private set; } = new List<Place>();

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

        public Itinerary(int itineraryId, int personId)
        {
            ItineraryId = itineraryId;
            PersonId = personId; 
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now; 
        }
        private SqlItineraryRepository repo = new SqlItineraryRepository(connectionString);
        public void Add(Place place)
        {
            foreach(Place p in Places)
            {
                if (place == p) return;
            }
            Places.Add(place);
            
            repo.SaveItinerary(ItineraryId, PersonId); 
        }

        public bool Remove(Place place)
        {
            foreach(Place p in Places)
            {
                if (place == p)
                {
                    Places.Remove(place);
                    repo.SaveItinerary(ItineraryId, PersonId);
                    return true;
                }
            }
            return false; 
        }
    }
}
