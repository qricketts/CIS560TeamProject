using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient; 
using KioskData.KioskModels;
using KioskData; 

namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";
        public ItineraryView ItineraryView;

        public Itinerary Itinerary;

        private PlaceView _placeView = null;
        private Person _currentUser; 

        
        public PlaceView GlobalPlaceView
        {
            get => _placeView;  
            set
            {
                if (_placeView == null)
                    _placeView = value;
                return; 
            }
        }

        private UIElement _borderViewsChild;
        public UIElement BorderViewsChild
        {
            get => _borderViewsChild;
            set
            {
                if (_borderViewsChild == value) return;
                _borderViewsChild = value;
                OnChildChanged(_borderViewsChild);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            var personRepo = new SqlPersonRepository(connectionString);
            var repo = new SqlItineraryRepository(connectionString);
            _currentUser = personRepo.CreatePerson("incomplete", "incomplete@ksu.edu", "1234"); 
            Itinerary = repo.CreateItinerary(_currentUser.PersonId);
            DataContext = Itinerary; 
            CategoryView categoryView = new CategoryView();
            ItineraryView = new ItineraryView(this);
            ChangeChild(categoryView);
        }

        public void ChangeChild(UIElement child)
        {
            if (child is ProfileView || child is ItineraryView)
            {
                btnItinerary.Visibility = Visibility.Hidden; 
            }
            else
            {
                btnItinerary.Visibility = Visibility.Visible;
            }
            borderViews.Child = child;
            BorderViewsChild = child;
        }

        public void OnChildChanged(object sender)
        {
            if (sender is CategoryView)
                textInformation.Text = "START by Selecting a Category";
            else if (sender is ItineraryView)
                textInformation.Text = Itinerary.Places.Count + " Items Present in Itinerary"; 
            else if (sender is ProfileView)
                textInformation.Text = "Enter email and password to load itinerary";
            else if (sender is PlacesList)
                textInformation.Text = "SELECT a place to see details";
            else if (sender is PlaceView)
                textInformation.Text = "";
        }

        private void OpenItinerary(object sender, RoutedEventArgs e)
        {
            ItineraryView.FillList(); 
            ChangeChild(ItineraryView);
        }
    }
}
