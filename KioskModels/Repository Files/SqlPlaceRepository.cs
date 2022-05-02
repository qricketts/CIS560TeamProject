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
    public class SqlPlaceRepository : IPlaceRepository
    {
        private readonly SqlCommandExecutor executor;
        private List<Place> _places; 
        public SqlPlaceRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<Place> RetrievePlaces()
        {
            List<Place> places = new List<Place>(); 
            using (StreamReader sr = new StreamReader("C:/Users/johnnyvgoode/Source/Repos/CIS560TeamProject/KioskModels/DummyData/PlaceData.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');
                    string address = values[3] + "," + values[4] + "," + values[5] + "," + values[6];
                    places.Add(new Place(Convert.ToInt32(values[0]), values[1], address, values[7]) 
                       { CategoryId = Convert.ToInt32(values[2]), CreatedOn = Convert.ToDateTime(values[8]), UpdatedOn = Convert.ToDateTime(values[9])}); 
                }

            }
            _places = places; 
            return places; 
        }

        public bool SavePlace(string name, int categoryId, string address, string description)
        {
            foreach(Place p in _places)
            
            {
                if (p.Name.Equals(name)) 
                    return false; 
            }

            string path = "C:/Users/johnnyvgoode/Source/Repos/CIS560TeamProject/KioskModels/DummyData/PlaceData.csv";
            string lastLine = File.ReadLines(path).Last();
            string[] values = lastLine.Split(',');
            int id = Convert.ToInt32(values[0]) + 1;
            string[] addressInfo = address.Split(','); 

            File.AppendAllText(path, id + "," + name + "," + categoryId + "," + addressInfo[0] + "," + addressInfo[1] + "," + addressInfo[2] + "," + addressInfo[3] + "," + description + "," 
                + DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm") + "," + DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm") + Environment.NewLine);

            RetrievePlaces(); 

            //add place to database

            return true; 
        }
    }
}
