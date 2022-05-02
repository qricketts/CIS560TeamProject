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
    internal class DeletePersonDataDelegate : DataDelegate
    {
        private readonly int personId;

        public DeletePersonDataDelegate(int personId)
           : base("Person.DeletePerson")
        {
            this.personId = personId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("PersonId", personId);
        }
    }
}
