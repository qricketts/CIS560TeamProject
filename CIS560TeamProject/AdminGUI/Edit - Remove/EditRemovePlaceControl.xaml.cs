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
    /// Interaction logic for EditRemovePlaceControl.xaml
    /// </summary>
    public partial class EditRemovePlaceControl : UserControl
    {
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";
        private string _name; 
        public string PlaceName
        {
            get => _name;
            set => _name = value; 
        }
        private string _address;
        public string PlaceAddress
        {
            get => _address;
            set => _address = value;
        }
        private string _description;
        public string PlaceDescription
        {
            get => _description;
            set => _description = value;
        }

        private CategorySelected _categorySelected = CategorySelected.Restaurants;
        public CategorySelected CategorySelected
        {
            get => _categorySelected;
            set => _categorySelected = value;
        }

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

        private Place _place;
        protected static string[] _categories = { "Restaurants", "Coffee Houses", "Recreational Activities", "Colleges", "Parks", "Shopping" };
        public EditRemovePlaceControl(Place place)
        {
            InitializeComponent();
            _place = place;
            PlaceName = place.Name;
            PlaceAddress = place.Address;
            PlaceDescription = place.Description;
            tbName.Text = PlaceName;
            tbAddress.Text = PlaceAddress;
            tbDescription.Text = PlaceDescription; 
            cbCategory.ItemsSource = _categories;
            cbCategory.SelectedIndex = 0; 
        }

        private void CategoryChanged(object sender, SelectionChangedEventArgs e)
        {
            CategorySelected = (CategorySelected)(cbCategory.SelectedIndex+1);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Name.Equals("tbName"))
                PlaceName = textbox.Text;
            else if (textbox.Name.Equals("tbAddress"))
                PlaceAddress = textbox.Text;
            else 
                PlaceDescription = textbox.Text;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow; 
            SqlPlaceRepository repo = new SqlPlaceRepository(connectionString);
            repo.SavePlace(_place.PlaceId, PlaceName, (int)CategorySelected, PlaceAddress, PlaceDescription);
            
            main.btnAdd.IsEnabled = true;
            main.btnEditRemove.IsEnabled = true;
            main.borderFilters.Child = main.FiltersControl;
            main.LoadData();
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            SqlPlaceRepository repo = new SqlPlaceRepository(connectionString);
            SqlItineraryPlaceRepository ipRepo = new SqlItineraryPlaceRepository(connectionString);

            List<ItineraryPlace> ips = ipRepo.RetrieveItineraryPlaces() as List<ItineraryPlace>;

            foreach (ItineraryPlace ip in ips)
            {
                if (ip.PlaceId == _place.PlaceId)
                {
                    ipRepo.DeleteItineraryPlace(ip.ItineraryPlaceId); 
                }
            }
            
            SqlRatingRepository rRepo = new SqlRatingRepository(connectionString);
            List<Rating> ratings = rRepo.RetrieveRatings() as List<Rating>; 
            foreach (Rating r in ratings)
            {
                if (r.PlaceId == _place.PlaceId)
                {
                    rRepo.DeleteRating(r.RatingId); 
                }
            }
            repo.DeletePlace(_place.PlaceId);
            main.btnAdd.IsEnabled = true;
            main.btnEditRemove.IsEnabled = true;
            main.borderFilters.Child = main.FiltersControl;
            main.LoadData(); 
        }
    }
}
