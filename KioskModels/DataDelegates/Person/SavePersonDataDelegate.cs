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
    internal class SavePersonDataDelegate : DataDelegate
    {
        private readonly int personId;
        private readonly string name;
        private readonly string email;
        private readonly string password;

        public SavePersonDataDelegate(int personId, string name, string email, string password) : base("Kiosk.SavePerson")
        {
            this.personId = personId;
            this.name = name;
            this.email = email;
            this.password = password; 
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("PersonId", personId);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Email", email);
            command.Parameters.AddWithValue("Password", password);
        }
    }
}
