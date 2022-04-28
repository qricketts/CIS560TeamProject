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
    /// Interaction logic for EditRemoveControl.xaml
    /// </summary>
    public partial class EditRemoveControl : UserControl
    {
        private readonly string EditRemoveType;
        public EditRemoveControl(string type)
        {
            InitializeComponent();
            EditRemoveType = type; 
            if (type.Equals("Place"))
            {
                borderTypeControl.Child = new EditRemovePlaceControl(new Place(""));
            }
            else if (type.Equals("Person"))
            {
                borderTypeControl.Child = new EditRemovePersonControl(new Person());
            }
            else
            {
                borderTypeControl.Child = new EditRemoveItineraryControl(new Itinerary());
            }
        }
    }
}
