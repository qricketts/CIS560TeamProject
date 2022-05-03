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
            Place originalPlace = _place;
            Place newPlace = new Place(originalPlace.PlaceId, (int)CategorySelected, PlaceName, PlaceAddress, PlaceDescription);


            SqlPlaceRepository repo = new SqlPlaceRepository(connectionString);
            repo.DeletePlace(originalPlace.PlaceId);
            repo.CreatePlace(PlaceName, (int)CategorySelected, PlaceAddress, PlaceDescription);
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            SqlPlaceRepository repo = new SqlPlaceRepository(connectionString);
            repo.DeletePlace(_place.PlaceId);
        }
    }
}
