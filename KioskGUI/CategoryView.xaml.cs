﻿using System;
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
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        private MainWindow _main; 
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


        public CategoryView()
        {
            InitializeComponent();
            MainWindow main = TraverseTreeForMainWindow;
        }

        private void OpenItinerary(object sender, RoutedEventArgs e)
        {
            
            ItineraryView itineraryView = new ItineraryView();
            _main.borderViews.Child = itineraryView;
            _main.ChangeChild(itineraryView); 
        }

        private void CategorySelected(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
