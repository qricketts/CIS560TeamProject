﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioskData.KioskModels;
using DataAccess;
using System.IO;
using KioskData; 

namespace KioskData
{
    public class SqlRatingRepository : IRatingRepository
    {
        private readonly SqlCommandExecutor executor;
        private readonly string connection; 
        private int _nextId =1; 
        public SqlRatingRepository(string connectionString)
        {
            connection = connectionString; 
            executor = new SqlCommandExecutor(connectionString);
        }
        public IReadOnlyList<Rating> RetrieveRatings()
        {
            List<Rating> ratings = new List<Rating>(); 
            using (StreamReader sr = new StreamReader("C:/Users/johnnyvgoode/Source/Repos/CIS560TeamProject/KioskModels/Repository Files/SqlRatingRepository.cs"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(','); 
                    _nextId = Convert.ToInt32(values[0]) + 1; 
                    int placeId = Convert.ToInt32(values[3]);
                    Place place = null; 
                    SqlPlaceRepository placeRepo = new SqlPlaceRepository(connection);
                    List<Place> places = placeRepo.RetrievePlaces() as List<Place>; 
                    foreach (Place p in places)
                    {
                        if (p.PlaceId == placeId)
                        {
                            place = p;
                            break; 
                        }
                    }
                    int personId = Convert.ToInt32(values[2]);
                    Person person = null;
                    SqlPersonRepository personRepo = new SqlPersonRepository(connection);
                    List<Person> people = personRepo.RetrievePeople() as List<Person>;

                    foreach (Person p in people)
                    {
                        if (p.PersonId == personId)
                        {
                            person = p;
                            break;
                        }
                    }
                    ratings.Add(new Rating(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), place, person)); 
                }
            }
            return ratings; 
        }

        public void SaveRating(int rating, Place place, Person person)
        {
            string path = "C:/Users/johnnyvgoode/Source/Repos/CIS560TeamProject/KioskModels/DummyData/RatingData.csv";
            File.AppendAllText(path, _nextId + "," + rating + "," + place + "," + person
                + DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm") + "," + DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm") + Environment.NewLine);
            _nextId++;
        }
    }
}