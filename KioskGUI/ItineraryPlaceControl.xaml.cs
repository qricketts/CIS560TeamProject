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
using System.ComponentModel; 

namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for ItineraryPlaceControl.xaml
    /// </summary>
    public partial class ItineraryPlaceControl : UserControl
    {
        private MainWindow _main; 
        private Place _place; 
        public ItineraryPlaceControl(Place p, MainWindow main)
        {
            InitializeComponent();
            _main = main; 
            _place = p;
            textName.Text = p.Name;
            textAddress.Text = p.Address; 
        }

        private void PlaceSelected(object sender, RoutedEventArgs e)
        {
            PlaceView pv = new PlaceView(_place, new PlacesList(CategorySelected.None));
            pv.btnBack.Content = "< Back";
            _main.ChangeChild(pv); 
        }

        private void RemoveFromItinerary(object sender, RoutedEventArgs e)
        {
            _main.Itinerary.Remove(_place); 
        }
    }
}
