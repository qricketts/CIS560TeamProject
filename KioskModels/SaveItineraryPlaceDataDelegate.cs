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
    internal class SaveItineraryPlaceDataDelegate : DataDelegate
    {
        private readonly int itineraryPlaceId;
        private readonly int itineraryId;
        private readonly int placeId;

        public SaveItineraryPlaceDataDelegate(int itineraryPlaceId, int itineraryId, int placeId) : base("Kiosk.SaveItineraryPlace")
        {
            this.itineraryPlaceId = itineraryPlaceId;
            this.itineraryId = itineraryId;
            this.placeId = placeId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("ItineraryPlaceId", itineraryPlaceId);
            command.Parameters.AddWithValue("ItineraryId", itineraryId);
            command.Parameters.AddWithValue("PlaceId", placeId);
        }
    }
}
