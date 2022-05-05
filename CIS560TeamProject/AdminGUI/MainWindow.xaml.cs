using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Syncfusion.Windows.Controls.Input;
using KioskData.KioskModels;
using KioskData;

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";
        private string _searchBarValue = ""; 
        public string SearchBarValue
        {
            get => _searchBarValue;
            set => _searchBarValue = value; 
        }

        private int _sfRatingValue = 1; 
        
        public int SfRatingValue
        {
            get => _sfRatingValue;
            set => _sfRatingValue = value; 
        }
        private CategorySelected _categorySelected = CategorySelected.Restaurants; 

        public CategorySelected CategorySelected
        {
            get => _categorySelected;
            set => _categorySelected = value; 
        }

        private DataTypeSelected _dataTypeSelected = DataTypeSelected.Place; 
        public DataTypeSelected DataTypeSelected
        {
            get => _dataTypeSelected;
            set => _dataTypeSelected = value; 
        }

        private BindingList<PlaceBindingItem> PlaceList = new BindingList<PlaceBindingItem>();
        private BindingList<PersonBindingItem> PersonList = new BindingList<PersonBindingItem>();
        private BindingList<ItineraryBindingItem> ItineraryList = new BindingList<ItineraryBindingItem>();

        public ReportsControl ReportsControl = new ReportsControl();
        public FiltersControl FiltersControl = new FiltersControl(); 

        public MainWindow()
        {
            InitializeComponent();
            borderReports.Child = ReportsControl;
            borderFilters.Child = FiltersControl;
        }
        
        public int GetItineraryPlaceCount(Place p)
        {
            int count = 0; 
            SqlItineraryPlaceRepository repo = new SqlItineraryPlaceRepository(connectionString);
            List<ItineraryPlace> itineraryPlaces = repo.RetrieveItineraryPlaces() as List<ItineraryPlace>; 
            foreach(ItineraryPlace ip in itineraryPlaces)
            {
                if (ip.PlaceId == p.PlaceId) count++; 
            }
            return count; 
        }

        public List<Rating> GetPlaceRatings(Place p, out int sumRatings)
        {
            SqlRatingRepository repo = new SqlRatingRepository(connectionString);
            List<Rating> ratings = new List<Rating>();
            sumRatings = 0;
            List<Rating> dbRatings = repo.RetrieveRatings() as List<Rating>; 
            foreach (Rating r in dbRatings)
            {
                if (r.Rate >= SfRatingValue && r.PlaceId == p.PlaceId)
                {
                    sumRatings += r.Rate; 
                    ratings.Add(r);
                } 
            }
            return ratings; 
        }
        public List<Rating> GetPersonRatings(Person p, out int sumRatings)
        {
            SqlRatingRepository repo = new SqlRatingRepository(connectionString);
            List<Rating> ratings = new List<Rating>();
            sumRatings = 0;
            List<Rating> dbRatings = repo.RetrieveRatings() as List<Rating>;
            foreach (Rating r in dbRatings)
            {
                if (r.Rate >= SfRatingValue && r.PersonId == p.PersonId)
                {
                    sumRatings += r.Rate;
                    ratings.Add(r);
                }
            }
            return ratings;
        }
        public void LoadData()
        {
            if (gridviewQuery.Columns.Count > 0)
                gridviewQuery.Columns.Clear();

            if (DataTypeSelected is DataTypeSelected.Place)
            {
                gridviewQuery = SetupPlaceQuery(gridviewQuery);
                PlaceList = new BindingList<PlaceBindingItem>();
                listviewQuery.ItemsSource = PlaceList;

                SqlPlaceRepository repo = new SqlPlaceRepository(connectionString);
                List<Place> dbPlaces = repo.RetrievePlaces() as List<Place>; 
                foreach(Place p in dbPlaces)
                {
                    int sumRatings; 
                    List<Rating> ratings = GetPlaceRatings(p, out sumRatings); 
                    if (p.CategoryId == (int)CategorySelected)
                    {
                        PlaceList.Add(new PlaceBindingItem(p, ratings.Count, sumRatings, GetItineraryPlaceCount(p), DateTime.Now)); 
                    }
                }
            }
            else if (DataTypeSelected is DataTypeSelected.Person)
            {
                gridviewQuery = SetupPersonQuery(gridviewQuery);
                PersonList = new BindingList<PersonBindingItem>();
                listviewQuery.ItemsSource = PersonList;
                SqlPersonRepository repo = new SqlPersonRepository(connectionString);
                List<Person> dbPeople = repo.RetrievePeople() as List<Person>;
                foreach (Person p in dbPeople)
                {
                    int sumRatings;
                    List<Rating> ratings = GetPersonRatings(p, out sumRatings);
                    double avg;
                    if (ratings.Count == 0) avg = 0; 
                    else avg = (double)sumRatings / ratings.Count; 
                   
                    PersonList.Add(new PersonBindingItem(p, ratings.Count, avg, p.CreatedOn, p.UpdatedOn)); 
                }
            }
            else
            {
                gridviewQuery = SetupItineraryQuery(gridviewQuery);
                ItineraryList = new BindingList<ItineraryBindingItem>();
                listviewQuery.ItemsSource = ItineraryList;
                SqlItineraryRepository repo = new SqlItineraryRepository(connectionString);
                List<Itinerary> dbItineraries = repo.RetrieveItineraries() as List<Itinerary>; 
                foreach (Itinerary i in dbItineraries)
                {
                    ItineraryList.Add(new ItineraryBindingItem(i, i.PersonId, i.CreatedOn, i.UpdatedOn)); 
                }
            }
            listviewQuery.View = gridviewQuery;
        }
        public GridView SetupReport1Query(GridView gv)
        {
            gv.Columns.Add(new GridViewColumn { Header = "PersonId", DisplayMemberBinding = new Binding("PersonId")});
            gv.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("Name") });
            gv.Columns.Add(new GridViewColumn { Header = "# of Ratings", DisplayMemberBinding = new Binding("NumRatings") { StringFormat = "{0:0.0}" }});
            gv.Columns.Add(new GridViewColumn { Header = "Average Rating", DisplayMemberBinding = new Binding("AverageRating") });
            return gv;
        }

        private GridView SetupPlaceQuery(GridView gv)
        {
            gv.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("Name"), Width = 200}); 
            gv.Columns.Add(new GridViewColumn { Header = "Address", DisplayMemberBinding = new Binding("Address")});
            gv.Columns.Add(new GridViewColumn { Header = "Avg Rating", DisplayMemberBinding = new Binding("AverageRating") { StringFormat = "{0:0.0}" }, Width = 120 });
            gv.Columns.Add(new GridViewColumn { Header = "# of Itineraries", DisplayMemberBinding = new Binding("ItineraryCount"), Width = 120 });
            gv.Columns.Add(new GridViewColumn { Header = "CreatedOn", DisplayMemberBinding = new Binding("CreatedOn") { StringFormat = "M/d/yyyy" }, Width = 150 });
            gv.Columns.Add(new GridViewColumn { Header = "UpdatedOn", DisplayMemberBinding = new Binding("UpdatedOn") { StringFormat = "M/d/yyyy" }, Width = 150 });
            return gv; 
        }

        private GridView SetupPersonQuery(GridView gv)
        {
            gv.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("Name"), Width = 240 });
            gv.Columns.Add(new GridViewColumn { Header = "Email", DisplayMemberBinding = new Binding("Email"), Width = 240 });
            gv.Columns.Add(new GridViewColumn { Header = "# Ratings", DisplayMemberBinding = new Binding("TotalRatings"), Width = 120 });
            gv.Columns.Add(new GridViewColumn { Header = "Avg Rating", DisplayMemberBinding = new Binding("AverageRating") { StringFormat = "{0:0.0}" }, Width = 120 });
            gv.Columns.Add(new GridViewColumn { Header = "CreatedOn", DisplayMemberBinding = new Binding("CreatedOn") { StringFormat = "M/d/yyyy" }, Width = 100 });
            gv.Columns.Add(new GridViewColumn { Header = "UpdatedOn", DisplayMemberBinding = new Binding("UpdatedOn") { StringFormat = "M/d/yyyy" }, Width = 100 });
            return gv; 
        }
        private GridView SetupItineraryQuery(GridView gv)
        {
            gv.Columns.Add(new GridViewColumn { Header = "Itinerary Owner", DisplayMemberBinding = new Binding("Name"), Width = 270 });
            gv.Columns.Add(new GridViewColumn { Header = "# Places", DisplayMemberBinding = new Binding("TotalPlaces"), Width = 140 });
            gv.Columns.Add(new GridViewColumn { Header = "CreatedOn", DisplayMemberBinding = new Binding("CreatedOn") { StringFormat = "M/d/yyyy" }, Width = 270 });
            gv.Columns.Add(new GridViewColumn { Header = "UpdatedOn", DisplayMemberBinding = new Binding("UpdatedOn") { StringFormat = "M/d/yyyy" }, Width = 270 });
            return gv; 
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadData(); 
        }
        
        private void SearchBarTextChanged(object sender, RoutedEventArgs e)
        {
            SearchBarValue = SearchBar.Text; 
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            borderReports.Child = new AddControl();
            btnAdd.IsEnabled = false;
            btnEditRemove.IsEnabled = false;
        }

        private void EditRemoveItem(object sender, RoutedEventArgs e)
        {
            if (listviewQuery.SelectedIndex == -1) return; 

            if (FiltersControl.rbPlace.IsChecked == true)
            {
                PlaceBindingItem placeBindingItem = listviewQuery.SelectedItem as PlaceBindingItem;
                borderFilters.Child = new EditRemoveControl(placeBindingItem.Place); 
            }
            else if (FiltersControl.rbPerson.IsChecked == true)
            {
                PersonBindingItem personBindingItem = listviewQuery.SelectedItem as PersonBindingItem; 
                borderFilters.Child = new EditRemoveControl(personBindingItem.Person);
            }
            else
            {
                ItineraryBindingItem itineraryBindingItem = listviewQuery.SelectedItem as ItineraryBindingItem; 
                borderFilters.Child = new EditRemoveControl(itineraryBindingItem.Itinerary);
            }
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
        }
    }
}
