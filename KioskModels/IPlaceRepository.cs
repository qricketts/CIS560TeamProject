using System.Collections.Generic;
using KioskData.KioskModels;

namespace KioskData
{
    public interface IPlaceRepository
    {
        IReadOnlyList<Place> RetrievePlaces();

        void SavePlace(string name, string address, string description, object maplink, object picture);
    }
}
