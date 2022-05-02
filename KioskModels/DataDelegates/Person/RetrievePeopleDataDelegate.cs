using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData;
using KioskData.KioskModels;
using KioskData.DataDelegates;
using DataAccess;
using System.Data.SqlClient;

namespace KioskData
{
    internal class RetrievePeopleDataDelegate : DataReaderDelegate<IReadOnlyList<Person>>
    {
        public RetrievePeopleDataDelegate() : base("Kiosk.RetrievePeople")
        {
        }

        public override IReadOnlyList<Person> Translate(SqlCommand command, IDataRowReader reader)
        {
            var people = new List<Person>(); 
            while (reader.Read())
            {
                people.Add(new Person(reader.GetInt32("PersonId"),
               reader.GetString("Name"),
               reader.GetString("Email"),
               reader.GetString("Password")));
            }
            return people; 
        }
    }
}
