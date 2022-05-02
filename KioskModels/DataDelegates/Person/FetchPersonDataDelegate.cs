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
    internal class FetchPersonDataDelegate : DataReaderDelegate<Person>
    {
        private readonly int personId;

        public FetchPersonDataDelegate(int personId)
           : base("Person.FetchPerson")
        {
            this.personId = personId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("PersonId", personId);
        }

        public override Person Translate(SqlCommand command, IDataRowReader reader)
        {
            return new Person(personId,
               reader.GetString("Name"),
               reader.GetString("Email"),
               reader.GetString("Password"));
        }
    }
}
