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
    /// Interaction logic for EditRemovePersonControl.xaml
    /// </summary>
    public partial class EditRemovePersonControl : UserControl
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
        const string connectionString = "Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team#5;Persist Security Info=True;User ID=velascoj;Password=Highland19!";
        private string _name; 
        public string PersonName
        {
            get => _name;
            set => _name = value; 
        }
        private string _email;
        public string PersonEmail
        {
            get => _email;
            set => _email = value;
        }
        private string _password;
        public string PersonPassword
        {
            get => _password;
            set => _password = value;
        }

        private Person _person; 
        public EditRemovePersonControl(Person person)
        {
            InitializeComponent();
            _person = person;
            PersonName = person.Name;
            tbName.Text = PersonName; 
            PersonEmail = person.Email;
            tbEmail.Text = PersonEmail; 
            PersonPassword = person.Password;
            tbPassword.Text = PersonPassword; 
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Name.Equals("tbName"))
                PersonName = textbox.Text;
            else if (textbox.Name.Equals("tbEmail"))
                PersonEmail = textbox.Text;
            else
                PersonPassword = textbox.Text;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow; 
            SqlPersonRepository repo = new SqlPersonRepository(connectionString);
            repo.SavePerson(_person.PersonId, PersonName, PersonEmail, PersonPassword);
            main.btnAdd.IsEnabled = true;
            main.btnEditRemove.IsEnabled = true;
            main.borderFilters.Child = main.FiltersControl;
            main.LoadData();
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            SqlPersonRepository repo = new SqlPersonRepository(connectionString);
            SqlItineraryRepository iRepo = new SqlItineraryRepository(connectionString);
            List<Itinerary> itineraries = iRepo.RetrieveItineraries() as List<Itinerary>; 

            foreach(Itinerary i in itineraries)
            {
                if (i.PersonId == _person.PersonId)
                    iRepo.DeleteItinerary(i.ItineraryId); 
            }
            SqlRatingRepository rRepo = new SqlRatingRepository(connectionString);
            List<Rating> ratings = rRepo.RetrieveRatings() as List<Rating>;
            foreach (Rating r in ratings)
            {
                if (r.PersonId == _person.PersonId)
                {
                    rRepo.DeleteRating(r.RatingId);
                }
            }
            repo.DeletePerson(_person.PersonId);
            main.btnAdd.IsEnabled = true;
            main.btnEditRemove.IsEnabled = true;
            main.borderFilters.Child = main.FiltersControl;
            main.LoadData();
        }
    }
}
