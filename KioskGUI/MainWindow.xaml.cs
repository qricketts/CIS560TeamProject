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

namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Itinerary CurrentItinerary = new Itinerary(); 

        private PlaceView _placeView = null; 
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
            DataContext = new Itinerary(); 
            CategoryView categoryView = new CategoryView();
            ChangeChild(categoryView);
        }

        public void ChangeChild(UIElement child)
        {
            borderViews.Child = child;
            BorderViewsChild = child;
        }

        public void OnChildChanged(object sender)
        {
            if (sender is CategoryView)
                textInformation.Text = "START by Selecting a Category";
            else if (sender is ItineraryView)
                textInformation.Text = "0 Items Present in Itinerary"; //use count from the CurrentItinerary.Places.Count property. 
            else if (sender is ProfileView)
                textInformation.Text = "Enter email and password to load itinerary";
            else if (sender is PlacesList)
                textInformation.Text = "Select a place...";
            else if (sender is PlaceView)
                textInformation.Text = "Add to Itinerary or Return to Category";
        }
    }
}
