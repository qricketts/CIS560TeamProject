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
    /// Interaction logic for AddEditRemoveView.xaml
    /// </summary>
    public partial class AddEditRemoveView : UserControl
    {
        private MainWindow _main; 
        public AddEditRemoveView(MainWindow main)
        {
            InitializeComponent();
            _main = main;
            textTitle.Text = "Kiosk Admin Interface";
        }

        private void FunctionSelected(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            _main.Function = button.Content.ToString();
            _main.ChangeChild(new ModelSelectionView(_main.Function));
        }
    }
}
