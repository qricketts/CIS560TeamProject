using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;
using System.IO;
using KioskData; 

namespace KioskData
{
    public class SqlRatingRepository : IRatingRepository
    {
        private readonly SqlCommandExecutor executor;
        private readonly string connection; 
        private int _nextId =1; 
        public SqlRatingRepository(string connectionString)
        {
            connection = connectionString; 
            executor = new SqlCommandExecutor(connectionString);
        }
        public void CreateRating(int ratingId, int rate, Place place, Person person)
        {
            var d = new CreateRatingsDataDelegate(ratingId, rate, place.PlaceId, person.PersonId);
            executor.ExecuteNonQuery(d);
        }
        public IReadOnlyList<Rating> RetrieveRatings()
        {
            return executor.ExecuteReader(new RetrieveRatingsDataDelegate());
        }

        public Rating FetchRating(int placeId)
        {
            var d = new FetchRatingsDataDelegate(placeId);
            return executor.ExecuteReader(d);
        }
    }
}
