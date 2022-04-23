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
        private CategoryView _categoryViewRef; 
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

            if (ItineraryHasPlace())
                btnAddRemove.Content = "Remove from Itinerary";
            else
                btnAddRemove.Content = "Add to Itinerary";
        }

        public bool ItineraryHasPlace()
        {
            MainWindow main = TraverseTreeForMainWindow;
            if (main is null) return false; 
            foreach (Place p in main.Itinerary.Places)
            {
                if (Place == p)
                    return true; 
            }
            return false; 
        }

        

        private void ReturnToCategory(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.ChangeChild(_placesList); 
        }

        private void AddRemovePlace(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            if (btnAddRemove.Content.Equals("Add to Itinerary"))
            {
                main.Itinerary.Add(Place);
                btnAddRemove.Content = "Remove from Itinerary"; 
            }
            else
            {
                main.Itinerary.Remove(Place);
                btnAddRemove.Content = "Add to Itinerary";
            }
            
        }
    }
}
