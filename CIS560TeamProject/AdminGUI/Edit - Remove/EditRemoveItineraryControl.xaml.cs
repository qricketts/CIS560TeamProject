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
using KioskData.KioskModels; 

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for EditRemoveItineraryControl.xaml
    /// </summary>
    public partial class EditRemoveItineraryControl : UserControl
    {
        private Itinerary _itinerary;
        private List<Place> _places; 
        public EditRemoveItineraryControl(Itinerary itinerary)
        {
            InitializeComponent();
            _itinerary = itinerary;
            _places = itinerary.Places; 
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            Itinerary originalItinerary = _itinerary;
            Itinerary newItinerary = new Itinerary();
            foreach (Place p in _places)
            {
                newItinerary.Add(p); 
            }
            //remove original, add new.
            throw new NotImplementedException(); 
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            //remove _itinerary from database. 
            throw new NotImplementedException(); 
        }

        private void RemoveItineraryItem(object sender, RoutedEventArgs e)
        {
            var selected = listviewItinerary.SelectedItem;
            foreach (Place p in _places)
            {
                //check for an itinerary item that was selected or the index and remove. 
                //_places.Remove(p); 
            }
            Itinerary newItinerary = new Itinerary();
            foreach(Place p in _places)
            {
                newItinerary.Add(p); 
            }
            throw new NotImplementedException(); 
        }
    }
}
