using System;
using System.Collections.Generic;
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
    /// Interaction logic for SoapStock.xaml
    /// </summary>
    public partial class SoapStock : Window, IDisposable
    {
        private SoapFactoryEntities se = new SoapFactoryEntities();
        public SoapStock()
        {
            InitializeComponent();
        }
        //Load window and set the datas in soap datagrid
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            se.SoapTable.Load();
            se.RecipeTable.Load();
            this.SoapstockDataGrid.ItemsSource = se.SoapTable.Local;
        }
        //Adding new soap
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            SoapDetails frm = new SoapDetails(new SoapTable());
            Nullable<bool> wantToSave = frm.ShowDialog();
            if (wantToSave.HasValue && wantToSave.Value == true)
            {
                SoapTable newSoap = frm.DataContext as SoapTable;
                se.SoapTable.Add(newSoap);
            }
        }
        //Add the new soap item to database
        public void AddToSoapTable(SoapTable st)
        {
            se.SoapTable.Add(st);
        }

        //Delete selected soap
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Check if selected item exist
            if (this.SoapstockDataGrid.SelectedItem != null)
            {
                SoapTable a = this.SoapstockDataGrid.SelectedItem as SoapTable;
                MessageBoxResult mbr = MessageBox.Show("Biztosan törölni akarja?", "SoapStock",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mbr == MessageBoxResult.Yes)
                {
                    se.SoapTable.Remove(a);
                }
            }
        }
        //Method to set the DataGrid for readonly
        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            this.SoapstockDataGrid.SelectionUnit = DataGridSelectionUnit.Cell;

            if (this.SoapstockDataGrid.SelectedCells.Count != 0)
            {
                //Recipe can not be modified, shows error message if user clicks on it
                int columnIndex = SoapstockDataGrid.SelectedCells[0].Column.DisplayIndex;
                if (columnIndex == 1)
                {
                    MessageBox.Show("A szappanhoz tartozó recept típusa nem változtatható meg");
                }
                // Sets Readonly property to editable mode
                SoapstockDataGrid.IsReadOnly = false;
                SoapTable a = this.SoapstockDataGrid.SelectedItem as SoapTable;
                a = SoapstockDataGrid.SelectedItem as SoapTable;
            }
        }

        //DataGrid becomes readonly as enter is pressed
        private void StopEditingEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                se.SaveChanges();
                this.SoapstockDataGrid.SelectionUnit = DataGridSelectionUnit.FullRow;
                SoapstockDataGrid.IsReadOnly = true;
            }
        }
        //Save changes into database
        private void SaveSoapButton_Click(object sender, RoutedEventArgs e)
        {
            se.SaveChanges();
            MessageBox.Show("Változtatások mentve");
        }
        // Cancel 
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //View recipe details in a new window
        private void GetRecipeDetailsEvent(object sender, MouseButtonEventArgs e)
        {
            se.RecipeTable.Load();
            DataGrid rd = sender as DataGrid;
            RecipeDetails recipeDetailsTable = new RecipeDetails();
            SoapTable recipeSearched = rd.SelectedItem as SoapTable;
            //string RecipeName = se.RecipeTable.Local.Where(x => x.IdRecipe == recipeSearched.IdRecipe).Select(x => x.Name).First();

            //get name of recipe
            int recipeId = recipeSearched.IdRecipe;
            string recipeName = se.RecipeTable.Where(x => x.IdRecipe == recipeId).Select(x => x.Name).First();

            //fill DataGrid with the details of searched recipe
            recipeDetailsTable.RecipeDetailsDataGrid.ItemsSource = se.RecipeTable.Local.Where(x => x.Name == recipeName).Select(x => x);
            recipeDetailsTable.ShowDialog();
        }

        public void Dispose()
        {
            if (se != null)
            {
                se.Dispose();
            }
        }
    }
}
