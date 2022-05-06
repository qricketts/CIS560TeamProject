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
    public class SqlItineraryPlaceRepository : IItineraryPlaceRepository
    {
        private readonly SqlCommandExecutor executor;
        private readonly string connection;

        public SqlItineraryPlaceRepository(string connectionString)
        {
            connection = connectionString;
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<ItineraryPlace> RetrieveItineraryPlaces()
        {
            return executor.ExecuteReader(new RetrieveItineraryPlacesDataDelegate()); 
        }

        public void SaveItineraryPlace(int ip, int i, int p)
        {
            var d = new SaveItineraryPlaceDataDelegate(ip, i, p);
            executor.ExecuteNonQuery(d); 
        }
        public void DeleteItineraryPlace(int id)
        {
            var d = new DeleteItineraryPlaceDataDelegate(id);
            executor.ExecuteNonQuery(d);
        }
    }
}
