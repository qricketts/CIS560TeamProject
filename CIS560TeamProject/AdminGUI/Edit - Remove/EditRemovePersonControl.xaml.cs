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
    /// Interaction logic for EditRemovePersonControl.xaml
    /// </summary>
    public partial class EditRemovePersonControl : UserControl
    {
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
            private get => _password;
            set => _password = value;
        }

        private Person _person; 
        public EditRemovePersonControl(Person person)
        {
            InitializeComponent();
            _person = person;
            //PersonName = person.Name;
            PersonEmail = person.Email;
            PersonPassword = person.Password; 
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
            Person originalPerson = _person;
            Person newPerson = new Person(1, PersonName, PersonEmail, PersonPassword);
            //remove originalPerson
            //add newPerson
            throw new NotImplementedException();
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            //remove _person;
        }
    }
}
