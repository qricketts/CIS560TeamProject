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

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _searchBarValue = ""; 
        public string SearchBarValue
        {
            get => _searchBarValue;
            set => _searchBarValue = value; 
        }

        private int _sfRatingValue = 0; 
        
        public int SfRatingValue
        {
            get => _sfRatingValue;
            set => _sfRatingValue = value; 
        }
        private CategorySelected _categorySelected;

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

        public void LoadData()
        {
            if (gridviewQuery.Columns.Count > 0)
                gridviewQuery.Columns.Clear();

            if (DataTypeSelected is DataTypeSelected.Place)
            {
                gridviewQuery = SetupPlaceQuery(gridviewQuery);
                PlaceList = new BindingList<PlaceBindingItem>(); 
                listviewQuery.ItemsSource = PlaceList;
                //PlaceList = GetPlaces(); 
                //PlaceList.Add(new PlaceBindingItem("test", "test2", 3.2, 10, DateTime.Now, DateTime.Now));

            }
            else if (DataTypeSelected is DataTypeSelected.Person)
            {
                gridviewQuery = SetupPersonQuery(gridviewQuery);
                PersonList = new BindingList<PersonBindingItem>();
                listviewQuery.ItemsSource = PersonList;
                //PersonList = GetPersons(); 
                //PersonList.Add(new PersonBindingItem("Person", "email", 333333, 10222, DateTime.Now, DateTime.Now));

            }
            else
            {
                gridviewQuery = SetupItineraryQuery(gridviewQuery);
                ItineraryList = new BindingList<ItineraryBindingItem>();
                listviewQuery.ItemsSource = ItineraryList;
                //ItineraryList = GetItineraries(); 
                //ItineraryList.Add(new ItineraryBindingItem("personNametime", 10, DateTime.Now, DateTime.Now));
            }
            listviewQuery.View = gridviewQuery;

            if (SfRatingValue == 0)
            {
                //do not filter by rating
            }
            if (CategorySelected is CategorySelected.None)
            {
                //use all categories. 
            }

            //throw new NotImplementedException(); 
            //load data from database using KioskData's SQL.Procedures and SQL.Data. 
        }

        private GridView SetupPlaceQuery(GridView gv)
        {
            gv.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("Name"), Width = 200 }); 
            gv.Columns.Add(new GridViewColumn { Header = "Address", DisplayMemberBinding = new Binding("Address"), Width = 200 });
            gv.Columns.Add(new GridViewColumn { Header = "Avg Rating", DisplayMemberBinding = new Binding("AverageRating"), Width = 120 });
            gv.Columns.Add(new GridViewColumn { Header = "# of Itineraries", DisplayMemberBinding = new Binding("ItineraryCount"), Width = 120 });
            gv.Columns.Add(new GridViewColumn { Header = "CreatedOn", DisplayMemberBinding = new Binding("CreatedOn"), Width = 150 });
            gv.Columns.Add(new GridViewColumn { Header = "UpdatedOn", DisplayMemberBinding = new Binding("UpdatedOn"), Width = 150 });
            return gv; 
        }

        private GridView SetupPersonQuery(GridView gv)
        {
            gv.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("Name"), Width = 240 });
            gv.Columns.Add(new GridViewColumn { Header = "Email", DisplayMemberBinding = new Binding("Email"), Width = 240 });
            gv.Columns.Add(new GridViewColumn { Header = "# Ratings", DisplayMemberBinding = new Binding("TotalRatings"), Width = 120 });
            gv.Columns.Add(new GridViewColumn { Header = "# Itineraries", DisplayMemberBinding = new Binding("TotalItineraries"), Width = 120 });
            gv.Columns.Add(new GridViewColumn { Header = "CreatedOn", DisplayMemberBinding = new Binding("CreatedOn"), Width = 115 });
            gv.Columns.Add(new GridViewColumn { Header = "UpdatedOn", DisplayMemberBinding = new Binding("UpdatedOn"), Width = 115 });
            return gv; 
        }
        private GridView SetupItineraryQuery(GridView gv)
        {
            gv.Columns.Add(new GridViewColumn { Header = "Itinerary Owner", DisplayMemberBinding = new Binding("Name"), Width = 270 });
            gv.Columns.Add(new GridViewColumn { Header = "# Places", DisplayMemberBinding = new Binding("TotalPlaces"), Width = 140 });
            gv.Columns.Add(new GridViewColumn { Header = "CreatedOn", DisplayMemberBinding = new Binding("CreatedOn"), Width = 270 });
            gv.Columns.Add(new GridViewColumn { Header = "UpdatedOn", DisplayMemberBinding = new Binding("UpdatedOn"), Width = 270 });
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
                //pass the Place associated with the listview control. 
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
    }
}
