using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;
using System.IO; 

namespace KioskData
{
    public class SqlItineraryRepository : IItineraryRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlItineraryRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public Itinerary CreateItinerary(int itineraryId, int personId)
        {
            var d = new CreateItineraryDataDelegate(itineraryId, personId);
            return executor.ExecuteNonQuery(d);
        }

        public Itinerary FetchItinerary(int itineraryId)
        {
            var d = new FetchItineraryDataDelegate(itineraryId);
            return executor.ExecuteReader(d);
        }

        public void DeleteItinerary(int itineraryId)
        {
            var d = new DeleteItineraryDataDelegate(itineraryId);
            executor.ExecuteNonQuery(d);
        }

        public IReadOnlyList<Itinerary> RetrieveItineraries()
        {
            return executor.ExecuteReader(new RetrieveItineraryDataDelegate());
        }

        public void SaveItinerary(int itineraryId, int personId)
        {
            var d = new SaveItineraryDataDelegate(itineraryId, personId);
            executor.ExecuteNonQuery(d);
        }
    }
}
