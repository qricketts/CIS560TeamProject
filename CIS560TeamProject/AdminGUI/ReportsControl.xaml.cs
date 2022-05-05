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

        private SqlPersonRepository personRepository = new SqlPersonRepository(connectionString);
        private SqlRatingRepository ratingRepository = new SqlRatingRepository(connectionString);

        private void AverageRatingPerPerson(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
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
            //loads listview with a list of people and their average rating. 
            //have to query all person's and their ratings.
        }

        private void MostCommonItineraryPlace(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            //loads listview with a list of places that have been added to the most itineraries. 
            //have to query all itineraries and their places.  
        }

        private void CategoryMostPopularPlaces(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            //loads listview with a list of most popular places per category.
            //have to query places by category. and their 
        }

        private void AverageRatingPerPlace(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            //loads listview with a list of places and their average rating over time. 
            //have to query all places with their ratings. 
        }
    }
}
