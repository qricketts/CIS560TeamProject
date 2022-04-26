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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _searchBarValue = ""; 
        public string SearchBarValue
        {
            get => _searchBarValue;
            set => _searchBarValue = value; 
        }

        private int _sfRatingValue = 0; 
        
        public int SfRatingValue
        {
            get => _sfRatingValue;
            set => _sfRatingValue = value; 
        }
        private CategorySelected _categorySelected;

        public CategorySelected CategorySelected
        {
            get => _categorySelected;
            set => _categorySelected = value; 
        }

        private DataTypeSelected _dataTypeSelected = DataTypeSelected.Place; 
        public DataTypeSelected DataTypeSelected
        {
            get => _dataTypeSelected;
            set => _dataTypeSelected = value; 
        }

        public MainWindow()
        {
            InitializeComponent();
            //this.ResizeMode = ResizeMode.CanMinimize;
            borderReports.Child = new ReportsControl();
            borderFilters.Child = new FiltersControl();
        }

        public void LoadData()
        {
            if (SfRatingValue == 0)
            {
                //do not filter by rating
            }
            if (CategorySelected is CategorySelected.None)
            {
                //use all categories. 
            }
                 
            //load data from database using KioskData's SQL.Procedures and SQL.Data. 
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadData(); 
        }
        
        private void SearchBarTextChanged(object sender, RoutedEventArgs e)
        {
            SearchBarValue = SearchBar.Text; 
        }
    }
}
