using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KioskData;
using KioskData.KioskModels; 

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for ReportsControl.xaml
    /// </summary>
    public partial class ReportsControl : UserControl
    {
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";
        private MainWindow TraverseTreeForMainWindow
        {
            get
            {
                DependencyObject parent = this;
                do
                {
                    parent = LogicalTreeHelper.GetParent(parent);
                }
                while (!(parent is null || parent is MainWindow));
                return (MainWindow)parent;
            }
        }
        public ReportsControl()
        {
            InitializeComponent();
        }

        private SqlCategoryRepository categoryRepository = new SqlCategoryRepository(connectionString); 
        private SqlPersonRepository personRepository = new SqlPersonRepository(connectionString);
        private SqlRatingRepository ratingRepository = new SqlRatingRepository(connectionString);
        private SqlItineraryPlaceRepository itineraryPlaceRepository = new SqlItineraryPlaceRepository(connectionString);
        private SqlItineraryRepository itineraryRepository = new SqlItineraryRepository(connectionString);
        private SqlPlaceRepository placeRepository = new SqlPlaceRepository(connectionString); 

        private void AverageRatingPerPerson(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.listviewQuery.Items.Clear();
            main.gridviewQuery = main.SetupReport1Query(main.gridviewQuery); 
            List<Person> people = personRepository.RetrievePeople() as List<Person>;
            List<Rating> ratings = ratingRepository.RetrieveRatings() as List<Rating>; 

            foreach (Person p in people)
            {
                int totalRatings = 0; int sumRatings = 0; double avg; 
                foreach (Rating r in ratings)
                {
                    if (r.PersonId == p.PersonId)
                    {
                        totalRatings++;
                        sumRatings += r.Rate; 
                    }
                }
                if (totalRatings == 0) avg = 0;
                else avg = sumRatings / totalRatings; 
                PersonAverageRating control = new PersonAverageRating(p.PersonId, p.Name, totalRatings, avg);
                main.listviewQuery.Items.Add(control); 
            }
        }

        private void MostCommonItineraryPlace(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.listviewQuery.Items.Clear();
            main.gridviewQuery = main.SetupReport2Query(main.gridviewQuery);
            List<ItineraryPlace> itineraryPlaces = itineraryPlaceRepository.RetrieveItineraryPlaces() as List<ItineraryPlace>;
            List<Place> places = placeRepository.RetrievePlaces() as List<Place>;

            int total, id; 
            foreach (Place p in places)
            {
                total = 0; id = p.PlaceId; 
                foreach(ItineraryPlace ip in itineraryPlaces)
                {
                    if (ip.PlaceId == p.PlaceId) total++; 
                }
                MostItineraryPlaces control = new MostItineraryPlaces(id, p.Name, p.CategoryId, total);
                main.listviewQuery.Items.Add(control); 
            }
        }

        private void CategoryMostPopularPlaces(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.listviewQuery.Items.Clear(); 

            main.gridviewQuery = main.SetupReport3Query(main.gridviewQuery);
            List<ItineraryPlace> itineraryPlaces = itineraryPlaceRepository.RetrieveItineraryPlaces() as List<ItineraryPlace>;
            List<Place> places = placeRepository.RetrievePlaces() as List<Place>;
            List<Category> categories = categoryRepository.RetrieveCategories() as List<Category>; 
            foreach (Category c in categories)
            {
                int total;
                int highest = 0;
                Place highestPlace = null; 
                foreach (Place p in places)
                {
                    total = 0;
                    foreach (ItineraryPlace ip in itineraryPlaces)
                    {
                        if (ip.PlaceId == p.PlaceId && p.CategoryId == c.CategoryId) total++;
                    }
                    if (total > highest)
                    {
                        highest = total;
                        highestPlace = p; 
                    }
                }
                MostPopularCategoryPlace control = new MostPopularCategoryPlace(highestPlace.Name, c.Name, highest);
                main.listviewQuery.Items.Add(control); 
            }
        }

        private void AverageRatingPerPlace(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.listviewQuery.Items.Clear();
            main.gridviewQuery = main.SetupReport4Query(main.gridviewQuery);

            List<Place> places = placeRepository.RetrievePlaces() as List<Place>;
            List<Rating> ratings = ratingRepository.RetrieveRatings() as List<Rating>;

            foreach (Place p in places)
            {
                int totalRatings = 0; int sumRatings = 0; double avg;
                foreach (Rating r in ratings)
                {
                    if (r.PersonId == p.PlaceId)
                    {
                        totalRatings++;
                        sumRatings += r.Rate;
                    }
                }
                if (totalRatings == 0) avg = 0;
                else avg = sumRatings / totalRatings;
                PlaceAverageRating control = new PlaceAverageRating(p.PlaceId, p.Name, totalRatings, avg);
                main.listviewQuery.Items.Add(control);
            }
        }
    }
}
