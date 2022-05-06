using DataAccess;
using KioskData.KioskModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData;

namespace KioskData
{
    internal class DeleteRatingDataDelegate : DataDelegate
    {
        private readonly int ratingId;
        public DeleteRatingDataDelegate(int ratingId) : base("Kiosk.DeleteRating")
        {
            this.ratingId = ratingId;
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("RatingId", ratingId);
        }
    }
}
