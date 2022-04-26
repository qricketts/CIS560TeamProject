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

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for FiltersControl.xaml
    /// </summary>
    public partial class FiltersControl : UserControl
    {
        protected static string[] _categories = { "--None Selected--", "Restaurants", "Coffee Houses", "Recreational Activities", "Colleges", "Parks", "Shopping" };
        protected static string[] _data = { "Place", "Person", "Itinerary" };
        private string _dataSelected = _data[0]; 
        private CategorySelected _categorySelected = CategorySelected.None;

        public FiltersControl()
        {
            InitializeComponent();
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
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
            ComboBoxItem item = sender as ComboBoxItem;
            _categorySelected = IndexToCategorySelected(cbCategory.SelectedIndex);
        }

        private void DataChanged(object sender, RoutedEventArgs e)
        {
            if (rbPlace.IsChecked == true)
                _dataSelected = _data[0];
            else if (rbPerson.IsChecked == true)
                _dataSelected = _data[1];
            else
                _dataSelected = _data[2]; 
        }
    }
}
