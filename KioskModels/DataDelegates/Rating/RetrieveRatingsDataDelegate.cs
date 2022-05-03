using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData;
using KioskData.KioskModels;
using KioskData.DataDelegates;
using DataAccess;
using System.Data.SqlClient;

namespace KioskData
{
    internal class RetrieveRatingsDataDelegate : DataReaderDelegate<IReadOnlyList<Rating>>
    {
        public RetrieveRatingsDataDelegate() : base("Kiosk.RetrieveRatings") { }
        public override IReadOnlyList<Rating> Translate(SqlCommand command, IDataRowReader reader)
        {
            var ratings = new List<Rating>(); 
            while (reader.Read())
            {
                ratings.Add(new Rating(reader.GetInt32("RatingId"),
                    reader.GetInt32("Rate"),
                    reader.GetInt32("PersonId"),
                    reader.GetInt32("PlaceId"))); 
            }
            return ratings; 
        }
    }
}
