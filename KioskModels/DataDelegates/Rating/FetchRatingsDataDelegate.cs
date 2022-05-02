using DataAccess;
using KioskData.KioskModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData
{
    internal class FetchRatingsDataDelegate : DataReaderDelegate<Rating>
    {
        private readonly int ratingId; 

        public FetchRatingsDataDelegate(int ratingId) : base("Kiosk.FetchRating")
        {
            this.ratingId = ratingId; 
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("RatingId", ratingId);
        }
        public override Rating Translate(SqlCommand command, IDataRowReader reader)
        {
            return new Rating(ratingId,
               reader.GetInt32("Rate"),
               reader.GetInt32("PlaceId"),
               reader.GetInt32("PersonId"));
        }
    }
}
