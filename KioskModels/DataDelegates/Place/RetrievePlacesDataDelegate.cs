using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData;
using KioskData.KioskModels;
using DataAccess;
using System.Data.SqlClient;

namespace KioskData
{
    internal class RetrievePlacesDataDelegate : DataReaderDelegate<IReadOnlyList<Place>>
    {
        public RetrievePlacesDataDelegate() : base("Kiosk.RetrievePlaces")
        {

        }
        public override IReadOnlyList<Place> Translate(SqlCommand command, IDataRowReader reader)
        {
            var places = new List<Place>();
            while (reader.Read())
            {
                places.Add(new Place(reader.GetInt32("PlaceIdd"),
                reader.GetInt32("CategoryId"),
                reader.GetString("Name"),
                reader.GetString("Email"),
                reader.GetString("Password")));
            }
            return places;
        }
    }
}
