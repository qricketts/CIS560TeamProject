using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;

namespace KioskData
{
    public class SqlPlaceRepository : IPlaceRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlPlaceRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<Place> RetrievePlaces()
        {
            throw new NotImplementedException();
        }

        public void SavePlace(string name, string address, string description, object maplink, object picture)
        {
            throw new NotImplementedException();
        }
    }
}
