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
using Syncfusion.Windows.Controls.Input; 



namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for FiltersControl.xaml
    /// </summary>
    public partial class FiltersControl : UserControl
    {
        protected static string[] _categories = { "--None Selected--", "Restaurants", "Coffee Houses", "Recreational Activities", "Colleges", "Parks", "Shopping" };

        private int _sfRatingValue = 0; 
        public int SfRatingValue
        {
            get => _sfRatingValue;
            set
            {
                _sfRatingValue = value;
                MainWindow main = TraverseTreeForMainWindow;
                main.SfRatingValue = _sfRatingValue; 
            }
        }

        private CategorySelected _categorySelected = CategorySelected.None;
        public CategorySelected CategorySelected
        {
            get => _categorySelected; 
            set
            {
                _categorySelected = value;
                MainWindow main = TraverseTreeForMainWindow;
                main.CategorySelected = _categorySelected; 
            }
        }
        private DataTypeSelected _dataTypeSelected = DataTypeSelected.Place; 
        public DataTypeSelected DataTypeSelected
        {
            get => _dataTypeSelected; 
            set
            {
                _dataTypeSelected = value;
                MainWindow main = TraverseTreeForMainWindow;
                main.DataTypeSelected = _dataTypeSelected; 
            }
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

        public FiltersControl()
        {
            InitializeComponent();
            foreach (string cat in _categories)
            {
                cbCategory.Items.Add(cat);
            }
        }


        private CategorySelected IndexToCategorySelected(int index)
        {
            CategorySelected category = CategorySelected.None;
            for (int i = 0; i < _categories.Length; i++)
            {
                if (i == index)
                    return (CategorySelected)index;
            }
            return category;
        }

        private void CategoryChanged(object sender, RoutedEventArgs e)
         {
            _categorySelected = IndexToCategorySelected(cbCategory.SelectedIndex);
            if (cbCategory.SelectedIndex != 0)
                LoadListView(); 
        }

        private void DataChanged(object sender, RoutedEventArgs e)
        {
            if (rbPlace.IsChecked == true)
                _dataTypeSelected = DataTypeSelected.Place;
            else if (rbPerson.IsChecked == true)
                _dataTypeSelected = DataTypeSelected.Person;
            else
                _dataTypeSelected = DataTypeSelected.Itinerary;
            if (TraverseTreeForMainWindow is not null)
                LoadListView(); 
        }

        private void RatingChanged(object sender, RoutedEventArgs e)
        {
            SfRating rating = sender as SfRating;
            SfRatingValue = (int)rating.PreviewValue;
            if (cbCategory.SelectedIndex != 0)
            {
                LoadListView(); 
            } 
        }

        private void LoadListView()
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.LoadData();
        }
    }
}