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
    internal class SaveItineraryDataDelegate : DataDelegate
    {
        private readonly int itineraryId;
        private readonly int personId;

        public SaveItineraryDataDelegate(int itineraryId, int personId) : base("Kiosk.SaveItinerary")
        {
            this.itineraryId = itineraryId; 
            this.personId = personId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("ItineraryId", itineraryId);
            command.Parameters.AddWithValue("PersonId", personId);
        }

    }
}
