using System.Collections.Generic;
using KioskData.KioskModels;

namespace KioskData
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Retrieves all categories in the database.
        /// </summary>
        /// <returns>IReadOnlyList of Categories in the database</returns>
        IReadOnlyList<Category> RetrieveCategories();

        void SaveCategory(string name);
    }
}
