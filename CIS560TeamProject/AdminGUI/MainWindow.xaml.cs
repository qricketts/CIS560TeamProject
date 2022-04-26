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
        private int _sfRatingValue = -1; 
        
        public int SfRatingValue
        {
            private get => _sfRatingValue;
            set => _sfRatingValue = value; 
        }
        private CategorySelected _categorySelected = CategorySelected.None; 

        public CategorySelected CategorySelected
        {
            private get => _categorySelected;
            set => _categorySelected = value; 
        }

        private DataTypeSelected _dataTypeSelected = DataTypeSelected.Place; 
        public DataTypeSelected DataTypeSelected
        {
            private get => _dataTypeSelected;
            set => _dataTypeSelected = value; 
        }

        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
            borderReports.Child = new ReportsControl();
            borderFilters.Child = new FiltersControl();
        }

        public void LoadData()
        {
            if (SfRatingValue < 0)
            {
                //do not filter by rating
            }
            if (CategorySelected is CategorySelected.None)
            {
                //use all categories. 
            }
                

            //look into filters that are set in local variable.s 
            //load data from database using KioskData's SQL.Procedures and SQL.Data. 
        }
    }
}
