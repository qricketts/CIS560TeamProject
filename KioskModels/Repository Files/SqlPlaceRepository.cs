using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;
using System.IO;
using KioskData.DataDelegates; 

namespace KioskData
{
    public class SqlPlaceRepository : IPlaceRepository
    {
        private readonly SqlCommandExecutor executor;
        public SqlPlaceRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public Place CreatePlace(string name, int categoryId, string address, string description)
        {
            var d = new CreatePlaceDataDelegate(name, categoryId, address, description);
            return executor.ExecuteNonQuery(d); 
        }
        public IReadOnlyList<Place> RetrievePlaces()
        {
            return executor.ExecuteReader(new RetrievePlacesDataDelegate()); 
        }

        public Place FetchPlace(int placeId)
        {
            var d = new FetchPlaceDataDelegate(placeId);
            return executor.ExecuteReader(d); 
        }
        public void DeletePlace(int placeId)
        {
            var d = new DeletePlaceDataDelegate(placeId);
            executor.ExecuteNonQuery(d);
        }

        public void SavePlace(int placeId,string name, int categoryId, string address, string description)
        {
            var d = new SavePlaceDataDelegate(placeId, categoryId, name, address, description);
            executor.ExecuteNonQuery(d); 
        }
    }
}
