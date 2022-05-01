using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;

namespace KioskData
{
    public class SqlItineraryPlaceRepository : IItineraryPlaceRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlItineraryPlaceRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<ItineraryPlace> RetrieveItineraryPlaces()
        {
            throw new NotImplementedException();
        }

        public void SaveIteneraryPlace(Place p, Itinerary i)
        {
            throw new NotImplementedException();
        }
    }
}
