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

namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for ItineraryView.xaml
    /// </summary>
    public partial class ItineraryView : UserControl
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


        public ItineraryView()
        {
            InitializeComponent();
        }

        private void ReturnToCategoryView(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            CategoryView cv = new CategoryView(); 
            main.ChangeChild(cv); 
        }

        private void OnProfileClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = TraverseTreeForMainWindow;
            ProfileView profile = new ProfileView();
            main.ChangeChild(profile); 
        }
    }
}
