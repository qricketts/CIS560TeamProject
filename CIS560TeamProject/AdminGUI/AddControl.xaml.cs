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

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for AddControl.xaml
    /// </summary>
    public partial class AddControl : UserControl
    {
        private string _currentType = "Place"; 
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
                Place newPlace = new Place(1, textbox1.Text, textbox2.Text, textbox3.Text);
                newPlace.Address = labelInfo2.Content.ToString();
                newPlace.Description = labelInfo3.Content.ToString();
            }
            else
            {
                Person newPerson = new Person(1, textbox1.Text, textbox2.Text, textbox3.Text);
                //newPerson.Name = labelInfo1.Content.ToString()
                newPerson.Email = labelInfo2.Content.ToString();
                newPerson.Password = labelInfo3.Content.ToString();
            }
            //add item to database using the procedure. 
            throw new NotImplementedException(); 
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
