using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using KioskData;
using DataAccess;
using System.IO;
using KioskData.DataDelegates;

namespace KioskData
{
    public class SqlPersonRepository : IPersonRepository
    {
        private readonly SqlCommandExecutor executor;
        public SqlPersonRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public Person CreatePerson(string name, string email, string password)
        {
            var d = new CreatePersonDataDelegate(name, email, password);
            return executor.ExecuteNonQuery(d); 
        }

        public Person FetchPerson(int personId)
        {
            var d = new FetchPersonDataDelegate(personId);
            return executor.ExecuteReader(d); 
        }

        public void DeletePerson(int personId)
        {
            var d = new DeletePersonDataDelegate(personId);
            executor.ExecuteNonQuery(d); 
        }

        public IReadOnlyList<Person> RetrievePeople()
        {
            return executor.ExecuteReader(new RetrievePeopleDataDelegate()); 
        }

        public void SavePerson(int id, string name, string email, string password)
        {
            var d = new SavePersonDataDelegate(id, name, email, password);
            executor.ExecuteNonQuery(d);
        }
    }
}
