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
    /// Interaction logic for RecipeDetails.xaml
    /// </summary>
    public partial class RecipeDetails : Window, IDisposable
    {
        SoapFactoryEntities se = new SoapFactoryEntities();

        public RecipeDetails()
        {
            InitializeComponent();
            this.RecipeDetailsDataGrid.ItemsSource = null;
        }

        //Loading window- filling up the window with the table elements
        private void RecipeDetailTable_Loaded(object sender, RoutedEventArgs e)
        {
            se.RecipeTable.Load();
        }

        //Delete selected row in a recipe
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.RecipeDetailsDataGrid.SelectedItem != null)
            {
                RecipeTable rowToRemove = this.RecipeDetailsDataGrid.SelectedItem as RecipeTable;
                string itemName = rowToRemove.Name;
                MessageBoxResult mbr = MessageBox.Show("Biztosan törölni akarja?", "SoapStock",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mbr == MessageBoxResult.Yes)
                {
                    //Select item to remove
                    RecipeTable itemSearched = se.RecipeTable.Local.Where(x => x.Name == rowToRemove.Name
                    && x.IdIngredient == rowToRemove.IdIngredient && x.Quantity == rowToRemove.Quantity).First();

                    se.RecipeTable.Local.Remove(itemSearched);
                    se.SaveChanges();
                    RecipeDetailsDataGrid.ItemsSource = se.RecipeTable.Local.Where(x => x.Name == itemName).ToList();
                }
            }
        }
        //Modify values
        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            RecipeDetailsDataGrid.IsReadOnly = false;
            RecipeTable item = RecipeDetailsDataGrid.SelectedItem as RecipeTable;
            item = RecipeDetailsDataGrid.DataContext as RecipeTable;
        }
        private void RecipeDetailsDataGrid_SelectionChanged(object sender, RoutedEventArgs e) { }

        //Cancel and return to previouse page
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Save database
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            se.SaveChanges();
            RecipeDetailsDataGrid.IsReadOnly = true;
            MessageBox.Show("Változtatások elmentve");
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
