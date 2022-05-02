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
    internal class DeleteItineraryDataDelegate : DataDelegate
    {
        private readonly int itineraryId;

        public DeleteItineraryDataDelegate(int itineraryId) : base("Kiosk.DeleteItinerary")
        {
            this.itineraryId = itineraryId; 
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("ItineraryId", itineraryId);
        }
    }
}
