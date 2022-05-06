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
using KioskData.KioskModels;

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for AddControl.xaml
    /// </summary>
    public partial class AddControl : UserControl
    {
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";
        private string _currentType = "Place";
        protected static string[] _categories = { "Restaurants", "Coffee Houses", "Recreational Activities", "Colleges", "Parks", "Shopping" };
        private CategorySelected _categorySelected = CategorySelected.Restaurants;
        public CategorySelected CategorySelected
        {
            get => _categorySelected;
            set => _categorySelected = value;
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

        public AddControl()
        {
            InitializeComponent();
            btnSubmit.IsEnabled = false;
            cbCategory.ItemsSource = _categories;
            cbCategory.SelectedIndex = 0; 
        }

        private void CategoryChanged(object sender, SelectionChangedEventArgs e)
        {
            CategorySelected = (CategorySelected)(cbCategory.SelectedIndex + 1); 
        }

        private void AddChanged(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            _currentType = button.Content.ToString();
            if (button.Content.Equals("Place"))
            {

                LoadPlaceControls(); 
            }
            else
            {
                
                LoadPersonControls(); 
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox1.Text.Length != 0 && textbox2.Text.Length != 0 && textbox3.Text.Length != 0)
                btnSubmit.IsEnabled = true;
            else btnSubmit.IsEnabled = false; 
        }

        private void LoadPlaceControls()
        {
            if (labelInfo1 is null) return; 
            labelInfo1.Content = "Name:";
            labelInfo2.Content = "Address:";
            labelInfo3.Content = "Description:";
            textbox1.Width = 350;
            textbox2.Width = 328;
            textbox3.Width = 293;
            textbox3.Height = 200;
        }
        private void LoadPersonControls()
        {
            if (labelInfo1 is null) return;
            labelInfo1.Content = "Name:";
            labelInfo2.Content = "Email:";
            labelInfo3.Content = "Password:";
            textbox1.Width = 350;
            textbox2.Width = 356;
            textbox3.Width = 314;
            textbox3.Height = 40;
        }

        private void SubmitNewItem(object sender, RoutedEventArgs e)
        {
            if (_currentType.Equals("Place"))
            {
                Place newPlace = new Place(1, (int)CategorySelected, textbox1.Text, textbox2.Text, textbox3.Text);
                SqlPlaceRepository repo = new SqlPlaceRepository(connectionString);
                repo.CreatePlace(newPlace.Name, newPlace.CategoryId, newPlace.Address, newPlace.Description); 
            }
            else
            {
                Person newPerson = new Person(1, textbox1.Text, textbox2.Text, textbox3.Text);
                SqlPersonRepository repo = new SqlPersonRepository(connectionString);
                repo.CreatePerson(newPerson.Name, newPerson.Email, newPerson.Password);
            }
            MainWindow main = TraverseTreeForMainWindow;
            main.btnAdd.IsEnabled = true;
            main.btnEditRemove.IsEnabled = true; 
            main.borderReports.Child = main.ReportsControl; 
        }

        private void CancelNewItem(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            main.btnAdd.IsEnabled = true;
            main.btnEditRemove.IsEnabled = true;
            main.borderReports.Child = main.ReportsControl;
        }
    }
}
