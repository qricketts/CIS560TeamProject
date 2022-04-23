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

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for ModelSelectionView.xaml
    /// </summary>
    public partial class ModelSelectionView : UserControl
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
        public ModelSelectionView(string function)
        {
            InitializeComponent();
            textTitle.Text = "Select an item to " + function.ToLower(); 
        }

        private void ModelSelected(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string model = button.Content.ToString();
            MainWindow main = TraverseTreeForMainWindow;
            main.ChangeChild(new ModelListView(model));
        }
    }
}
