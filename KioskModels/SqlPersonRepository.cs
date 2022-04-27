using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;

namespace KioskData
{
    public class SqlPersonRepository : IPersonRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlPersonRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<Person> RetrievePeople()
        {
            throw new NotImplementedException();
        }

        public void SavePerson(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
