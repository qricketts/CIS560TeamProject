using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;
using System.IO;

namespace KioskData
{
    public class SqlItineraryPlaceRepository : IItineraryPlaceRepository
    {
        private readonly SqlCommandExecutor executor;
        private readonly string connection;

        public SqlItineraryPlaceRepository(string connectionString)
        {
            connection = connectionString;
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<ItineraryPlace> RetrieveItineraryPlaces()
        {
            List<ItineraryPlace> itineraryPlaces = new List<ItineraryPlace>();
            using (StreamReader sr = new StreamReader(""))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');
                    int itineraryId = Convert.ToInt32(values[1]);
                    int placeId = Convert.ToInt32(values[2]);

                    Itinerary itinerary = null;
                    Place place = null;

                    SqlItineraryRepository itinRepo = new SqlItineraryRepository(connection);
                    foreach (Itinerary i in itinRepo.RetrieveItineraries())
                    {
                        if (i.ItineraryId == itineraryId)
                        {
                            itinerary = i;
                            break;
                        }
                    }
                    SqlPlaceRepository placeRepo = new SqlPlaceRepository(connection);
                    foreach (Place p in placeRepo.RetrievePlaces())
                    {
                        if (p.PlaceId == placeId)
                        {
                            place = p;
                            break;
                        }
                    }
                    itineraryPlaces.Add(new ItineraryPlace(Convert.ToInt32(values[0]), itinerary, place));
                }
            }
            return itineraryPlaces;
        }

        public void SaveItineraryPlace(Place p, Itinerary i)
        {
            List<ItineraryPlace> itineraryPlaces = RetrieveItineraryPlaces() as List<ItineraryPlace>;
            foreach (ItineraryPlace ip in itineraryPlaces)
            {
                if (p.PlaceId == ip.Place.PlaceId && i.ItineraryId == ip.Itinerary.ItineraryId) return;
            }
            string path = "C:/Users/johnnyvgoode/Source/Repos/CIS560TeamProject/KioskModels/DummyData/ItineraryPlaceData.csv";
            int id = File.ReadLines(path).Count() + 1;
            File.AppendAllText(path, id + "," + i.ItineraryId + "," + p.PlaceId + ","
                + DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm") + "," + DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm") + Environment.NewLine);
        }
    }
}
