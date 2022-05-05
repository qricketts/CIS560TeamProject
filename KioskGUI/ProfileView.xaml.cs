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
using KioskData; 


namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";

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
            //btnLogin.IsEnabled = false; 
            MainWindow main = TraverseTreeForMainWindow;
        }

        private void LoadProfile(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow; 
            string email = textboxEmail.Text;
            string password = textboxPassword.Text;
            SqlPersonRepository repo = new SqlPersonRepository(connectionString);
            List<Person> people = repo.RetrievePeople() as List<Person>;
            foreach(Person p in people)
            {
                if (p.Email.Equals(email))
                {
                    main.CurrentUser = p;
                }
                    
            }
            main.ItineraryView = new(main); 
            main.ChangeChild(main.ItineraryView); 
        }

        private void CreateProfile(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            string name = textboxCreateName.Text; 
            string email = textboxCreateEmail.Text;
            string password = textboxCreatePassword.Text;
            SqlPersonRepository repo = new SqlPersonRepository(connectionString);
            repo.SavePerson(main.CurrentUser.PersonId, name, email, password); 
            main.ItineraryView = new(main); 
            main.ChangeChild(main.ItineraryView);
        }
    }
}