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

namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
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
        public ProfileView()
        {
            InitializeComponent();
            MainWindow main = TraverseTreeForMainWindow;
        }

        private void LoadProfile(object sender, RoutedEventArgs e)
        {
            string email = textboxEmail.Text;
            string password = textboxPassword.Text;
            //check if database has the email, then verify the password, hash it too. 

            MainWindow main = TraverseTreeForMainWindow;
            main.ItineraryView = new(main); 
            //update itinerary view to have the places from the profile. 
            main.ChangeChild(main.ItineraryView); 

            throw new NotImplementedException("Complete ProfileView.LoadProfile() code"); 
        }

        private void CreateProfile(object sender, RoutedEventArgs e)
        {
            string name = textboxCreateName.Text; 
            string email = textboxCreateEmail.Text;
            string password = textboxCreatePassword.Text;
            //check if database has email, if not then add to database as a Person. 
            
            MainWindow main = TraverseTreeForMainWindow;
            main.ItineraryView = new(main); 
            //link itinerary view to the profile being used. Updating it in the db for each removal and addition. 
            main.ChangeChild(main.ItineraryView);

            throw new NotImplementedException("Complete ProfileView.CreateProfile() code"); 
        }

    }
}
