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
    internal class RetrieveItineraryPlacesDataDelegate : DataReaderDelegate<IReadOnlyList<ItineraryPlace>>
    {
        public RetrieveItineraryPlacesDataDelegate() : base("Kiosk.RetrieveItineraryPlaces")
        {

        }
        public override IReadOnlyList<ItineraryPlace> Translate(SqlCommand command, IDataRowReader reader)
        {
            var ip = new List<ItineraryPlace>();
            while (reader.Read())
            {
                ip.Add(new ItineraryPlace(reader.GetInt32("ItineraryPlaceId"),
                reader.GetInt32("ItineraryId"),
                reader.GetInt32("PlaceId")));
            }
            return ip;
        }
    }
}
