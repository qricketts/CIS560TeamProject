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
    public class SqlItineraryRepository : IItineraryRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlItineraryRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<Itinerary> RetrieveItineraries()
        {
            List<Itinerary> itineraries = new List<Itinerary>(); 
            using (StreamReader sr = new StreamReader(""))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');
                    int id = Convert.ToInt32(values[0]);
                    Itinerary itinerary = new Itinerary();
                    List<Place> places = RetrieveItineraries() as List<Place>;
                    foreach (Place p in places)
                    {
                        if (p.PlaceId == id)
                        {
                            itinerary.Add(p);
                            break;
                        }
                    }
                    itineraries.Add(itinerary);
                }
            }
            return itineraries; 
        }

        public void SaveItinerary(Itinerary itineraryToSave)
        {
            List<Itinerary> itineraries = RetrieveItineraries() as List<Itinerary>; 
            string path = "C:/Users/johnnyvgoode/Source/Repos/CIS560TeamProject/KioskModels/DummyData/ItineraryData.csv";
            foreach (Itinerary i in itineraries)
            {
                if (i.ItineraryId == itineraryToSave.ItineraryId)
                {
                    itineraries.Remove(i);
                    itineraries.Add(itineraryToSave);
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        foreach(Itinerary it in itineraries)
                        {
                            StringBuilder sb = new StringBuilder(it.ItineraryId); 
                            foreach(Place p in it.Places)
                            {
                                sb.Append("," + p.PlaceId); 
                            }
                            sw.WriteLine(sb.ToString()); 
                        }
                    }
                    return; 
                }
            }
            int id = File.ReadLines(path).Count() + 1;
            StringBuilder sb2 = new StringBuilder(id); 
            foreach(Place p in itineraryToSave.Places)
            {
                sb2.Append("," + p.PlaceId);
            }
            File.AppendAllText(path, sb2.ToString()); 
        }
    }
}
