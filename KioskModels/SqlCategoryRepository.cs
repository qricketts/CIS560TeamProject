using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using KioskData.KioskModels;

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
            throw new NotImplementedException();
        }

        public void SaveCategory(string name)
        {
            throw new NotImplementedException();
        }
    }
}
