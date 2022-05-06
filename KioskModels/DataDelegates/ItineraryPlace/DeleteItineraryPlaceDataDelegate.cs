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
    public class DeleteItineraryPlaceDataDelegate : DataDelegate
    {
        private readonly int itineraryPlaceId;

        public DeleteItineraryPlaceDataDelegate(int itineraryPlaceId) : base("Kiosk.DeleteItineraryPlace")
        {
            this.itineraryPlaceId = itineraryPlaceId;
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("ItineraryPlaceId", itineraryPlaceId);
        }
    }
}
