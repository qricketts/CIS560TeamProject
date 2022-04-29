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
        public EditRemoveControl(Place place)
        {
            InitializeComponent();
            borderTypeControl.Child = new EditRemovePlaceControl(place);
        }

        public EditRemoveControl(Person person)
        {
            InitializeComponent();
            borderTypeControl.Child = new EditRemovePersonControl(person);
        }

        public EditRemoveControl(Itinerary itinerary)
        {
            InitializeComponent();
            borderTypeControl.Child = new EditRemoveItineraryControl(itinerary);
        }
    }
}
