using System;
using DataAccess;
using System.Data.SqlClient;
using KioskData.KioskModels;
using System.Data;

namespace KioskData
{
    internal class CreateItineraryDataDelegate : NonQueryDataDelegate<Itinerary>
    {
        public readonly int personId;
        public CreateItineraryDataDelegate(int personId) : base("Kiosk.CreateItinerary")
        {
            this.personId = personId; 
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonId", personId);

            var p = command.Parameters.Add("ItineraryId", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Itinerary Translate(SqlCommand command)
        {
            return new Itinerary((int)command.Parameters["ItineraryId"].Value, personId); 
        }
    }
}
