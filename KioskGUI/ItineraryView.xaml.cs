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
    /// Interaction logic for ItineraryView.xaml
    /// </summary>
    public partial class ItineraryView : UserControl
    {

        private BindingList<ItineraryPlaceControl> ItineraryPlaceControls = new BindingList<ItineraryPlaceControl>();
        private MainWindow _main; 
        public ItineraryView(MainWindow main)
        {
            InitializeComponent();
            lvItinerary.ItemsSource = ItineraryPlaceControls; 
            _main = main; 
            if (_main is null) return; 
            FillList(); 
        }

        public void FillList()
        {
            ItineraryPlaceControls.Clear();
            foreach(Place p in _main.Itinerary.Places)
            {
                ItineraryPlaceControls.Add(new ItineraryPlaceControl(p, _main));
            }
        }

        private void ReturnToCategoryView(object sender, RoutedEventArgs e)
        {
            CategoryView cv = new CategoryView();
            _main.ChangeChild(cv); 
        }

        private void OnProfileClick(object sender, RoutedEventArgs e)
        {
            ProfileView profile = new ProfileView();
            _main.ChangeChild(profile); 
        }
    }
}
