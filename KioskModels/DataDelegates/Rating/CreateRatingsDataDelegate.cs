using System;
using DataAccess;
using System.Data.SqlClient;
using KioskData.KioskModels;
using System.Data;

namespace KioskData
{
    internal class CreateRatingsDataDelegate : NonQueryDataDelegate<Rating>
    {
        public readonly int ratingId; 
        public readonly int rate;
        public readonly int placeId;
        public readonly int personId;

        public CreateRatingsDataDelegate(int id, int rate, int placeId, int personId) : base("Kiosk.CreateRating")
        {
            this.ratingId = id;
            this.rate = rate;
            this.placeId = placeId;
            this.personId = personId;
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("RatingId", ratingId);
            command.Parameters.AddWithValue("Rate", rate);
            command.Parameters.AddWithValue("PlaceId", placeId);
            command.Parameters.AddWithValue("PersonId", personId);

            var p = command.Parameters.Add("RatingId", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Rating Translate(SqlCommand command)
        {
            return new Rating((int)command.Parameters["RatingId"].Value, rate, placeId, personId);
        }
    }
}
