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
    /// Interaction logic for PlaceControl.xaml
    /// </summary>
    public partial class PlaceControl : UserControl
    {
        private Place _place; 
        public PlaceControl(Place p)
        {
            InitializeComponent();
            _place = p; 
        }
    }
}
