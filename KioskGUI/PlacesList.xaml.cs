using System;
using System.Windows;
using System.Windows.Controls;
using KioskData;
using KioskData.KioskModels;
using System.ComponentModel;
using System.Collections.Generic;

namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for PlacesList.xaml
    /// </summary>
    public partial class PlacesList : UserControl
    {
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";
        private CategorySelected _categorySelected; 
        public CategorySelected CategorySelected
        {
            get => _categorySelected;
            private set => _categorySelected = value; 
        }

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

        private BindingList<PlaceControl> PlaceControls = new BindingList<PlaceControl>();
        private string[] _sorts = { "Alphabetical", "Most Popular", "Highest Rated"}; 

        public PlacesList(CategorySelected category)
        {
            InitializeComponent();
            listviewPlaces.ItemsSource = PlaceControls;
            foreach (string s in _sorts)
                cbSort.Items.Add(s);
            CategorySelected = category;
            FillList();
            labelCategoryName.Content = CategorySelected.ToString().ToUpper();
            labelTotalPlaces.Content = PlaceControls.Count.ToString() + " PLACES"; 
        }

        private void FillList()
        {
            SqlPlaceRepository repo = new SqlPlaceRepository(connectionString);

            List<Place> list = new List<Place>();
            List<Place> places = repo.RetrievePlaces() as List<Place>; 
            foreach(Place p in places)
            {
                if (p.CategoryId == (int)CategorySelected)
                {
                    list.Add(p);
                    PlaceControls.Add(new PlaceControl(p, this)); 
                }
            }
        }

        private void SortChanged(object sender, SelectionChangedEventArgs e)
        {
            //maybe not today
            string selected = cbSort.SelectedItem.ToString(); 
            switch (selected)
            {
                case "Most Popular":

                    break;
                case "Highest Rated":
                    break;
                default: //"Alphabetical"
                    break; 
            }       
        }

        private void ReturnToCategorySelection(object sender, RoutedEventArgs e)
        {
            CategoryView cv = new CategoryView();
            MainWindow main = TraverseTreeForMainWindow;
            main.ChangeChild(cv);
        }
    }
}