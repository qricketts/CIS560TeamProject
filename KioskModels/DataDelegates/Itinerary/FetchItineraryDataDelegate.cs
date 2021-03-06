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
    internal class FetchItineraryDataDelegate : DataReaderDelegate<Itinerary>
    {
        private readonly int itineraryId;
        public FetchItineraryDataDelegate(int itineraryId) : base("Kiosk.FetchItinerary")
        {
            this.itineraryId = itineraryId; 
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ItineraryId", itineraryId);
        }

        public override Itinerary Translate(SqlCommand command, IDataRowReader reader)
        {
            return new Itinerary(itineraryId, reader.GetInt32("PersonId")); 
        }
    }
}
