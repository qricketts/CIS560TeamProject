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

namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
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

        public CategoryView()
        {
            InitializeComponent();
        }

        private void OnCategorySelection(object sender, RoutedEventArgs e)
        {
            Button selected = sender as Button;
            string buttonName = selected.Name;
            PlacesList list = new PlacesList(GetCategorySelected(buttonName));
            MainWindow main = TraverseTreeForMainWindow; 
            main.ChangeChild(list);  
        }

        private CategorySelected GetCategorySelected(string name)
        {
            switch (name)
            {
                case "btnRestaurants":
                    return CategorySelected.Restaurants;
                case "btnColleges":
                    return CategorySelected.Colleges;
                case "btnCoffee":
                    return CategorySelected.Coffee;
                case "btnParks":
                    return CategorySelected.Parks;
                case "btnRecreational":
                    return CategorySelected.Recreation;
                default:
                    return CategorySelected.Shopping; 
            }
        }
    }
}
