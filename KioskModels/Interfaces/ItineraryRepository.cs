using System.Collections.Generic;
using KioskData.KioskModels;

namespace KioskData
{
    public interface IItineraryRepository
    {
        IReadOnlyList<Itinerary> RetrieveItineraries();

        void SaveItinerary(Itinerary itinerary);
    }
}
