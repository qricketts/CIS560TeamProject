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
        }

        private void LoadProfile(object sender, RoutedEventArgs e)
        {
            string email = textboxEmail.Text;
            string password = textboxPassword.Text;
            //check if database has the email, then verify the password, hash it too. 

            ItineraryView iv = new ItineraryView();
            MainWindow main = TraverseTreeForMainWindow;
            //update itinerary view to have the places from the profile. 
            main.ChangeChild(iv); 

            throw new NotImplementedException("Complete ProfileView.LoadProfile() code"); 
        }

        private void CreateProfile(object sender, RoutedEventArgs e)
        {
            string email = textboxCreateEmail.Text;
            string password = textboxCreatePassword.Text;
            //check if database has email, if not then add to database as a Person. 

            ItineraryView iv = new ItineraryView();
            MainWindow main = TraverseTreeForMainWindow;
            //link itinerary view to the profile being used. Updating it in the db for each removal and addition. 
            main.ChangeChild(iv);

            throw new NotImplementedException("Complete ProfileView.CreateProfile() code"); 
        }
    }
}
