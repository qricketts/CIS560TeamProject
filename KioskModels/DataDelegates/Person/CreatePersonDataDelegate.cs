using System;
using DataAccess;
using System.Data.SqlClient;
using KioskData.KioskModels;
using System.Data;

namespace KioskData.DataDelegates
{
    internal class CreatePersonDataDelegate : NonQueryDataDelegate<Person>
    {
        public readonly string name;
        public readonly string email;
        public readonly string password;
        public CreatePersonDataDelegate(string name, string email, string password) :
            base("Kiosk.CreatePerson")
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Email", email);
            command.Parameters.AddWithValue("Password", password);

            var p = command.Parameters.Add("PersonId", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Person Translate(SqlCommand command)
        {
            return new Person((int)command.Parameters["PersonId"].Value, name, email, password);
        }
    }
}
