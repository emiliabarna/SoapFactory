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
    /// Interaction logic for IngredientStockWindow.xaml
    /// </summary>
    public partial class IngredientStockWindow : Window
    {
        private SoapFactoryEntities se = new SoapFactoryEntities();
        public delegate void IsEnterPressedEvent(object sender, KeyEventArgs e);
  
        public IngredientStockWindow()
        {
            InitializeComponent();
        }

        //Load window and set the itemsource of ingredientDataGrid
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            se.IngredientTable.Load();
            this.IngStockDataGrid.ItemsSource = se.IngredientTable.Local;       
        }

        //Close page
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Add new ingredient
        private void btnNewIng_Click(object sender, RoutedEventArgs e)
        {
            NewIngredientPage ingT = new NewIngredientPage();
            Nullable<bool> wantToSave = ingT.ShowDialog();
            if (wantToSave.HasValue && wantToSave.Value == true)
            {
                IngredientTable newIng = ingT.DataContext as IngredientTable;
                se.IngredientTable.Add(newIng);
            }  
        }
        //Delete row
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.IngStockDataGrid.SelectedItem != null)
            {
                IngredientTable a = this.IngStockDataGrid.SelectedItem as IngredientTable;
                MessageBoxResult mbr = MessageBox.Show("Biztosan törölni akarja?", "IngredientStockWindow", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mbr == MessageBoxResult.Yes)
                {
                    se.IngredientTable.Remove(a);
                }
            }
        }
        //Save table
        private void SaveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            se.SaveChanges();
            MessageBox.Show("Változtatások mentve");
        }

        //Method to set the DataGrid for readonly
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            IngStockDataGrid.IsReadOnly = false;
            IngredientTable item = IngStockDataGrid.SelectedItem as IngredientTable;
            item = IngStockDataGrid.DataContext as IngredientTable;

        }
        //DataGrid becomes readonly as enter is pressed
        private void StopEditingEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                se.SaveChanges();
                IngStockDataGrid.IsReadOnly = true;
            }

        }
    }
}

