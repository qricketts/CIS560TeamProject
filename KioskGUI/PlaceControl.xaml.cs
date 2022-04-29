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
        private MainWindow TraverseTreeForMainWindow
        {
            get
            {
                DependencyObject parent = _placesList;
                do
                {
                    parent = LogicalTreeHelper.GetParent(parent);
                }
                while (!(parent is null || parent is MainWindow));
                return (MainWindow)parent; 
            }
        }

        private Place _place;
        private PlacesList _placesList;
        public PlaceControl(Place p, PlacesList list)
        {
            InitializeComponent();
            _place = p;
            _placesList = list;
            textName.Text = _place.Name;
            textAddress.Text = _place.Address; 
        }

        private void PlaceSelected(object sender, RoutedEventArgs e)
        {
            PlaceView pv = new PlaceView(_place, _placesList);
            pv.btnBack.Content = "< " + _placesList.CategorySelected.ToString(); 
            MainWindow main = TraverseTreeForMainWindow;
            main.ChangeChild(pv); 
        }
    }
}
