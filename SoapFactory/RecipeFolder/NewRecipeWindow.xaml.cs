using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace SoapFactory
{
    /// <summary>
    /// Interaction logic for New_RecipeWindow.xaml
    /// </summary>
    public partial class New_RecipeWindow : Window, IDisposable
    {
       private SoapFactoryEntities se = new SoapFactoryEntities();

        //List that contains the row of recipes
        public ObservableCollection<RecipeTable> recipeParts = new ObservableCollection<RecipeTable>();

        //Constructor
        public New_RecipeWindow()
        {
 
            InitializeComponent();
            this.NewRecipeDetailsDataGrid.ItemsSource = recipeParts;

        }
        //Load window and set the ingredient datas into combobox
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            se.IngredientTable.Load();
            this.cmbIngredients.ItemsSource = se.IngredientTable.Local;
        }

        private void NewRecipeDetailsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        //Adding a new row
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            NewRecipeDetailsDataGrid.CanUserAddRows = DataGrid.CanUserAddRowsProperty.ReadOnly;
            recipeParts.Add(new RecipeTable() { Name = recipeParts[0].Name, Date = recipeParts[0].Date });
        }

        //Removing a row 
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.NewRecipeDetailsDataGrid.SelectedItem != null)
            {
                RecipeTable a = this.NewRecipeDetailsDataGrid.SelectedItem as RecipeTable;
                MessageBoxResult mbr = MessageBox.Show("Biztosan törölni akarja?", "NewRecipeWindow",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mbr == MessageBoxResult.Yes)
                {
                    recipeParts.Remove(a);
                }
            }
        }
        // Cancel
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        //Saving recipe into database
        private void btnSaveDataBase_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        public void Dispose()
        {
            if(se!=null)
            {
                se.Dispose();
            }
        }
    }
}
