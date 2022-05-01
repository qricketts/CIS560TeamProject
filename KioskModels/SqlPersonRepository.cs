using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;
using System.IO; 

namespace KioskData
{
    public class SqlPersonRepository : IPersonRepository
    {
        private readonly SqlCommandExecutor executor;
        private int _nextPersonId; 
        public SqlPersonRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<Person> RetrievePeople()
        {
            List<Person> people = new List<Person>();
            using (StreamReader sr = new StreamReader("DummyData/PersonData"))
            {
                string line = sr.ReadLine();
                string[] values = line.Split(',');
                people.Add(new Person(Convert.ToInt32(values[0]), values[1], values[2], "123")
                    { CreatedOn = Convert.ToDateTime(values[3]), UpdatedOn = Convert.ToDateTime(values[4])});
                _nextPersonId = Convert.ToInt32(values[0])+1; 
            }
            return people; 
        }

        public void SavePerson(string name, string email, string password)
        {
            using (StreamWriter sw = new StreamWriter("DummyData/PersonData"))
            {
                sw.WriteLine(_nextPersonId + "," + email + "," + name + "," + password + "," + DateTime.Now + "," + DateTime.Now); 
            }
                
        }
    }
}
