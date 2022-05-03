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
using KioskData.KioskModels;
using KioskData; 

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for EditRemoveItineraryControl.xaml
    /// </summary>
    public partial class EditRemoveItineraryControl : UserControl
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

        private BindingList<ItineraryItem> ItemList = new BindingList<ItineraryItem>();
        private Itinerary _itinerary;
        public EditRemoveItineraryControl(Itinerary itinerary)
        {
            InitializeComponent();
            _itinerary = itinerary;
            listviewItinerary.ItemsSource = ItemList; 
            LoadItinerary(); 
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            SqlItineraryRepository repo = new SqlItineraryRepository(connectionString);
            repo.SaveItinerary(_itinerary.ItineraryId, _itinerary.PersonId);
        }

        private void RemoveItinerary(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.borderFilters.Child = main.FiltersControl; 
        }

        private void RemoveItineraryItem(object sender, RoutedEventArgs e)
        {
            if (ItemList.Count == 0 || listviewItinerary.SelectedIndex == -1) return; 
            ItineraryItem item = listviewItinerary.SelectedItem as ItineraryItem;
            
            if (_itinerary.Places.Contains(item.Place))
                _itinerary.Places.Remove(item.Place);
            if (ItemList.Contains(item))
                ItemList.Remove(item); 
        }
        private void LoadItinerary()
        {
            gridviewItinerary.Columns.Clear();
            gridviewItinerary.Columns.Add(new GridViewColumn { Header = "Place", DisplayMemberBinding = new Binding("PlaceName"), Width = 230 });
            gridviewItinerary.Columns.Add(new GridViewColumn { Header = "Date Added", DisplayMemberBinding = new Binding("DateAdded"), Width = 230 });
            foreach(Place p in _itinerary.Places)
            {
                ItemList.Add(new ItineraryItem(p)); 
            }
        }

        private void CancelChanges(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.borderFilters.Child = main.FiltersControl; 
        }
    }
}
