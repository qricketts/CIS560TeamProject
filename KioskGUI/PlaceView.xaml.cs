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

namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for PlaceView.xaml
    /// </summary>
    public partial class PlaceView : UserControl
    {
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
        private PlacesList _placesList; 

        private Place _place; 
        public Place Place
        {
            get => _place;
            private set => _place = value; 
        }

        public PlaceView(Place p, PlacesList list)
        {
            InitializeComponent();
            Place = p;
            _placesList = list; 
            PlaceControl pc = new PlaceControl(Place);
            borderPlace.Child = pc;
        }

        private void ReturnToCategory(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.ChangeChild(_placesList); 
        }

        private void AddPlaceToItinerary(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            //main.CurrentItinerary.AddPlace(p); 
            ItineraryView iv = new ItineraryView();
            //{ Itinerary = main.CurrentItinerary}
            main.ChangeChild(iv); 
        }
    }
}
