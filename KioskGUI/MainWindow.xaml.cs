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
        public Person CurrentUser
        {
            get => _currentUser; 
            set
            {
                _currentUser = value;
                UpdateItinerary(); 
            }
        }
        
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
            CurrentUser = personRepo.CreatePerson("incomplete", "incomplete@ksu.edu", "1234"); 
            Itinerary = repo.CreateItinerary(CurrentUser.PersonId);
            DataContext = Itinerary; 
            CategoryView categoryView = new CategoryView();
            ItineraryView = new ItineraryView(this);
            ChangeChild(categoryView);
        }

        private void UpdateItinerary()
        {
            if (Itinerary is null) return; 
            SqlItineraryRepository itineraryRepo = new SqlItineraryRepository(connectionString);
            List<Itinerary> itineraries = itineraryRepo.RetrieveItineraries() as List<Itinerary>;
            foreach (Itinerary i in itineraries)
            {
                if (i.PersonId == _currentUser.PersonId)
                {
                    Itinerary = i;
                    break;
                }
            }
            SqlItineraryPlaceRepository ipRepo = new SqlItineraryPlaceRepository(connectionString);
            List<ItineraryPlace> iPlaces = ipRepo.RetrieveItineraryPlaces() as List<ItineraryPlace>;
            SqlPlaceRepository placeRepo = new SqlPlaceRepository(connectionString);
            List<Place> places = placeRepo.RetrievePlaces() as List<Place>;
            foreach (ItineraryPlace ip in iPlaces)
            {
                if (ip.ItineraryId == Itinerary.ItineraryId)
                {
                    foreach(Place p in places)
                    {
                        if (p.PlaceId == ip.PlaceId) 
                            Itinerary.Add(p);
                    }
                }
            }
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
            {
                textTitle.Text = "My Itinerary"; 
                textInformation.Text = Itinerary.Places.Count + " Items Present in Itinerary"; 
            }
            else if (sender is ProfileView)
            {
                textTitle.Text = "My Profile"; 
                textInformation.Text = "Sign in to Save Itinerary";
            }
            else if (sender is PlacesList)
                textInformation.Text = "SELECT a Place to See Details";
            else if (sender is PlaceView)
                textInformation.Text = "Add or Remove from Itinerary";

            if (!CurrentUser.Name.Equals("incomplete"))
            {
                if (sender is ItineraryView)
                {
                    textTitle.Text = CurrentUser.Name + "'s Itinerary"; 
                }
            }
        }

        private void OpenItinerary(object sender, RoutedEventArgs e)
        {
            ItineraryView.FillList(); 
            ChangeChild(ItineraryView);
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            SqlItineraryRepository irepo = new SqlItineraryRepository(connectionString);
            SqlPersonRepository repo = new SqlPersonRepository(connectionString);
            //irepo.DeleteItinerary(155);
            repo.DeletePerson(170);

            if (CurrentUser.Name.Equals("incomplete"))
            {
                irepo.DeleteItinerary(Itinerary.ItineraryId);
                repo.DeletePerson(CurrentUser.PersonId); 
            }
        }
    }
}
