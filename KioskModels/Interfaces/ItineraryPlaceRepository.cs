using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;

namespace KioskData
{
    public interface IItineraryPlaceRepository
    {
        /// <summary>
        /// Retrieves all itineraryplaces in the database.
        /// </summary>
        /// <returns>IReadOnlyList of ItineraryPlaces in the database</returns>
        IReadOnlyList<ItineraryPlace> RetrieveItineraryPlaces();

        void SaveItineraryPlace(Place p, Itinerary i);
    }
}
