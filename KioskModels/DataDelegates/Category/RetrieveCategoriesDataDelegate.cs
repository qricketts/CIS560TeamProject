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
    internal class RetrieveCategoriesDataDelegate : DataReaderDelegate<IReadOnlyList<Category>>
    {
        public RetrieveCategoriesDataDelegate() : base("Kiosk.RetrieveCategories")
        {

        }
        public override IReadOnlyList<Category> Translate(SqlCommand command, IDataRowReader reader)
        {
            var categories = new List<Category>();
            while (reader.Read())
            {
                categories.Add(new Category(reader.GetInt32("CategoryId"), reader.GetString("Name")));
            }
            return categories;
        }
    }
}
