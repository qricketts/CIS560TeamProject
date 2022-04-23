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
    /// Interaction logic for PlacesList.xaml
    /// </summary>
    public partial class PlacesList : UserControl
    {
        private string _category;

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

        public PlacesList(string category)
        {
            InitializeComponent();
            _category = category;
        }

        private void ReturnToCategorySelection(object sender, RoutedEventArgs e)
        {
            CategoryView cv = new CategoryView();
            MainWindow main = TraverseTreeForMainWindow;
            main.ChangeChild(cv);
        }

        private void OnPlaceSelection(object sender, RoutedEventArgs e)
        {
            //sender as Place, setting all values, then opening the PlaceView with the Place and its details. 
            var CHANGE_ME = (sender as ListView).SelectedItem;
            Place p = new Place("name");
            PlaceView pv = new PlaceView(p, this);
            pv.btnBack.Content = "< " + _category;
            MainWindow main = TraverseTreeForMainWindow;
            main.ChangeChild(pv);
        }

    }

}
