using System.Collections.Generic;
using KioskData.KioskModels;

namespace KioskData
{
    public interface IPlaceRepository
    {
        IReadOnlyList<Place> RetrievePlaces();

        bool SavePlace(string name, int categoryId, string address, string description);
    }
}
