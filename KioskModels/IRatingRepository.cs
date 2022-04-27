using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;

namespace KioskData
{
    public interface IRatingRepository
    {
        IReadOnlyList<Rating> RetrieveRatings();

        void SaveRating(int rating, Place place, Person person);
    }
}
