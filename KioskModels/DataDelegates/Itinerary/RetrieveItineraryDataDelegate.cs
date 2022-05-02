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
    internal class RetrieveItineraryDataDelegate : DataReaderDelegate<IReadOnlyList<Itinerary>>
    {
        public RetrieveItineraryDataDelegate() : base("Kiosk.RetrieveItinerary")
        {
        }

        public override IReadOnlyList<Itinerary> Translate(SqlCommand command, IDataRowReader reader)
        {
            var itineraries = new List<Itinerary>();
            while (reader.Read())
            {
                itineraries.Add(new Itinerary(reader.GetInt32("ItineraryId"), reader.GetInt32("PersonId")));
            }
            return itineraries;
        }
    }
}
