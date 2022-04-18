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
    /// Interaction logic for PlaceView.xaml
    /// </summary>
    public partial class PlaceView : UserControl
    {
        private Place _place; 
        public Place Place
        {
            get => _place;
            private set => _place = value; 
        }

        public PlaceView(Place p)
        {
            InitializeComponent();
            Place = p;
            PlaceControl pc = new PlaceControl(Place);
            borderPlace.Child = pc;
        }
    }
}
