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
    internal class SavePlaceDataDelegate : DataDelegate
    {
        private readonly int placeId;
        private readonly int categoryId;
        private readonly string name;
        private readonly string address;
        private readonly string description; 

        public SavePlaceDataDelegate(int placeId, int categoryId, string name, string address, string description) : base("Kiosk.SavePlace") 
        {
            this.placeId = placeId;
            this.categoryId = categoryId;
            this.name = name;
            this.address = address;
            this.description = description;
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("PlaceId", placeId);
            command.Parameters.AddWithValue("CategoryId", categoryId);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Address", address);
            command.Parameters.AddWithValue("Description", description);
        }
    }
}
