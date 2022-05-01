using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;

namespace KioskData
{
    public class SqlRatingRepository : IRatingRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlRatingRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<Rating> RetrieveRatings()
        {
            throw new NotImplementedException();
        }

        public void SaveRating(int rating, Place place, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
