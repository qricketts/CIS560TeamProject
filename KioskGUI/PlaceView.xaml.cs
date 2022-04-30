using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KioskData; 
using KioskData.KioskModels;
using System.ComponentModel; 

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
            labelName.Content = Place.Name.ToUpper(); 
            textDescription.Text = "Description: \t" + p.Description;
            textAddress.Text = "Address: \t" + p.Address;
            textRatings.Text = "Ratings: \t\t☆"; // + p.Ratings.Average() + "(" + p.Ratings.Count + ")"; 

            if (TraverseTreeForMainWindow is null && list.CategorySelected is CategorySelected.None)
            {
                btnAddRemove.Content = "Remove from Itinerary";
                return; 
            }

            if (ItineraryHasPlace())
                btnAddRemove.Content = "Remove from Itinerary";
            else
                btnAddRemove.Content = "Add to Itinerary";
        }

        public bool ItineraryHasPlace()
        {
            MainWindow main = TraverseTreeForMainWindow;
            if (main is null) return false;

            if (main.Itinerary.Places.Contains(Place)) return true; 
            else return false; 
        }

        private void ReturnToCategory(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            if (_placesList.CategorySelected is CategorySelected.None)
            {
                main.ItineraryView.FillList(); 
                main.ChangeChild(main.ItineraryView); 
            }
                
            else 
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
