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
    /// Interaction logic for EditRemovePlaceControl.xaml
    /// </summary>
    public partial class EditRemovePlaceControl : UserControl
    {
        private string _name; 
        public string PlaceName
        {
            get => _name;
            set => _name = value; 
        }
        private string _address;
        public string PlaceAddress
        {
            get => _address;
            set => _address = value;
        }
        private string _description;
        public string PlaceDescription
        {
            get => _description;
            set => _description = value;
        }

        private Place _place; 
        public EditRemovePlaceControl(Place place)
        {
            InitializeComponent();
            _place = place;
            PlaceName = place.Name;
            PlaceAddress = place.Address;
            PlaceDescription = place.Description; 
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Name.Equals("tbName"))
                PlaceName = textbox.Text;
            else if (textbox.Name.Equals("tbAddress"))
                PlaceAddress = textbox.Text;
            else 
                PlaceDescription = textbox.Text;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            Place originalPlace = _place;
            Place newPlace = new Place(originalPlace.PlaceId, PlaceName, PlaceAddress, PlaceDescription);

            //remove originalPlace
            //add newPlace
            throw new NotImplementedException();

        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            //remove _place
            throw new NotImplementedException(); 
        }
    }
}
