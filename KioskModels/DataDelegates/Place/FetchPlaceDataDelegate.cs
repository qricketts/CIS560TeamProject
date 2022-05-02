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
    internal class FetchPlaceDataDelegate : DataReaderDelegate<Place>
    {
        private readonly int placeId; 

        public FetchPlaceDataDelegate(int placeId) : base("Kiosk.FetchPlace")
        {
            this.placeId = placeId; 
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PlaceId", placeId);
        }
        public override Place Translate(SqlCommand command, IDataRowReader reader)
        {
            return new Place(placeId,
                reader.GetInt32("CategoryId"),
                reader.GetString("Name"),
                reader.GetString("Email"),
                reader.GetString("Password"));
        }
    }
}
