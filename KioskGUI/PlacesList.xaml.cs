using System;
using System.Windows;
using System.Windows.Controls;
using KioskData;
using KioskData.KioskModels;
using System.ComponentModel; 

namespace KioskGUI
{
    /// <summary>
    /// Interaction logic for PlacesList.xaml
    /// </summary>
    public partial class PlacesList : UserControl
    {
        private CategorySelected _categorySelected; 
        public CategorySelected CategorySelected
        {
            get => _categorySelected;
            private set => _categorySelected = value; 
        }

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

        private BindingList<PlaceControl> PlaceControls = new BindingList<PlaceControl>();
        private string[] _sorts = { "Alphabetical", "Most Popular", "Highest Rated"}; 

        public PlacesList(CategorySelected category)
        {
            InitializeComponent();
            listviewPlaces.ItemsSource = PlaceControls;
            foreach (string s in _sorts)
                cbSort.Items.Add(s);
            CategorySelected = category;
            FillList();
            labelCategoryName.Content = CategorySelected.ToString().ToUpper();
            labelTotalPlaces.Content = PlaceControls.Count.ToString() + " PLACES"; 
        }

        private void FillList()
        {
            //retreive dummy data from KioskData to fill the category's list. 
            PlaceControls.Add(new PlaceControl(new Place(1001, "McDonalds","Manhattan, KS", "CUT TO: SEQ. 95 - GRAquite a bit of pomp...under * the circumstances. * " +
                "They land in their seats.BARRY(CONT'D) Well Adam, today we are men. Bee Movie - JS REVISIONS 8/13/07 5. ADAM We are. BARRY Bee-men. ADAM Amen! BARRY Hallelujah. " +
                "Barry hits Adam's forehead.Adam goes into the rapture.An announcement comes over the PA.ANNOUNCER(V.O) Students, faculty, distinguished bees...please welcome, " +
                "Dean Buzzwell.ANGLE ON: DEAN BUZZWELL steps up to the podium.The podium has a sign that reads: Welcome Graduating Class of: with train - station style flipping numbers " +
                "after it.BUZZWELL Welcome New Hive City graduating class of... The numbers"), this));
        }

        private void SortChanged(object sender, SelectionChangedEventArgs e)
        {
            //use sql sort by repository according the to sort chosen.
        }

        private void ReturnToCategorySelection(object sender, RoutedEventArgs e)
        {
            CategoryView cv = new CategoryView();
            MainWindow main = TraverseTreeForMainWindow;
            main.ChangeChild(cv);
        }
    }
}