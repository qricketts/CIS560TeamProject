using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;

namespace KioskData
{
    public class SqlItineraryRepository : IItineraryRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlItineraryRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<Itinerary> RetrieveItineraries()
        {
            throw new NotImplementedException();
        }

        public void SaveItinerary(List<Place> p)
        {
            throw new NotImplementedException();
        }
    }
}
