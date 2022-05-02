using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using KioskData;
using DataAccess;
using System.IO;

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
            List<Person> people = new List<Person>();
            using (StreamReader sr = new StreamReader("C:/Users/johnnyvgoode/Source/Repos/CIS560TeamProject/KioskModels/DummyData/PersonData.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');
                    people.Add(new Person(Convert.ToInt32(values[0]), values[1], values[2], values[3])
                    { CreatedOn = Convert.ToDateTime(values[4]), UpdatedOn = Convert.ToDateTime(values[5]) });
                }

            }
            return people;
        }

        public void SavePerson(string name, string email, string password)
        {
            string path = "C:/Users/johnnyvgoode/Source/Repos/CIS560TeamProject/KioskModels/DummyData/PersonData.csv";
            int id = File.ReadLines(path).Count() + 1;
            File.AppendAllText(path, id + "," + email + "," + name + "," + password + ","
                + DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm") + "," + DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm") + Environment.NewLine);
        }
    }
}
