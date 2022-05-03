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

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for ReportsControl.xaml
    /// </summary>
    public partial class ReportsControl : UserControl
    {
        public ReportsControl()
        {
            InitializeComponent();
            btnCategoryMostPopularPlace.IsEnabled = false;
            btnMostCommonItineraryPlace.IsEnabled = false;
            btnPersonAverageRating.IsEnabled = false;
            btnPlaceAverageRating.IsEnabled = false; 
        }

        private void AverageRatingPerPerson(object sender, RoutedEventArgs e)
        {
            
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
