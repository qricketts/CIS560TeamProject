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
    internal class DeletePlaceDataDelegate : DataDelegate
    {
        private readonly int placeId; 
        public DeletePlaceDataDelegate(int placeId) : base("Kiosk.DeletePlace")
        {
            this.placeId = placeId; 
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("Placeid", placeId); 
        }
    }
}
