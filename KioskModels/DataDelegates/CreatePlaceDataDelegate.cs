using System;
using DataAccess;
using System.Data.SqlClient;
using KioskData.KioskModels;
using System.Data;

namespace KioskData.DataDelegates
{
    internal class CreatePlaceDataDelegate : NonQueryDataDelegate<Place>
    {
        public readonly string name;
        public readonly string address;
        public readonly string description;
        public CreatePlaceDataDelegate(string name, string address, string description):
            base("Place.CreatePlace")
        {
            this.name = name;
            this.address = address;
            this.description = description;
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Address", address);
            command.Parameters.AddWithValue("Description", description);

            var p = command.Parameters.Add("PlaceId", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Place Translate(SqlCommand command)
        {
            return new Place ((int)command.Parameters["PlaceId"].Value, name, address, description);
        }
    }
}
