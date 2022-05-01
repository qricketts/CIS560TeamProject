using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using KioskData.KioskModels;
using System.IO; 

namespace KioskData
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlCategoryRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<Category> RetrieveCategories()
        {
            List<Category> categories = new List<Category>();
            using (StreamReader sr = new StreamReader("DummyData/CategoryData.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');
                    categories.Add(new Category(Convert.ToInt32(values[0]), values[1])); 
                }
            }
            return categories; 
        }
        /* We will not have the Add Category Function in this build. 
        public void SaveCategory(string name)
        {
            throw new NotImplementedException();
        }
        */
    }
}
