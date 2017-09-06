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
    /// Interaction logic for IngredientFinancialTable.xaml
    /// </summary>
    public partial class IngredientFinancialTable : Window
    {
        SoapFactoryEntities se = new SoapFactoryEntities();

        public IngredientFinancialTable()
        {
            InitializeComponent();
        }
        //Load window
        private void WindowLoadedEvent(object sender, RoutedEventArgs e)
        {
            se.IngredientStockTable.Load();
            se.IngredientTable.Load();
            this.IngredientFinDataGrid.ItemsSource = se.IngredientStockTable.Local;     
        }

        //Go back to previous page
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Add new ingredient movement
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
                //creating new window
            NewBoughtIngredientWindow newItemPage = new NewBoughtIngredientWindow(new IngredientStockTable());

            //setting the properties of new item
            Nullable<bool> wantToSave = newItemPage.ShowDialog();
            if (wantToSave.HasValue && wantToSave.Value == true)
            {
                IngredientStockTable newIngredient = newItemPage.NewIngredientContainer.DataContext as IngredientStockTable;
                se.IngredientStockTable.Add(newIngredient);

                //Increasing the amount of existing ingredient
                IngredientTable existingIngredient = se.IngredientTable.Where(x => x.IdIngredient == newIngredient.IdIngredient).First();
                if (existingIngredient.Stock != null)
                {
                    existingIngredient.Stock += (float)newIngredient.Quantity;
                }
                else
                {
                    existingIngredient.Stock = (float)newIngredient.Quantity;
                }
                //se.FinancialTable.Add(new FinancialTable() { IsSelling = false, Amount = (double)newIngredient.Price });
            }
        }

        //Save database
        private void SaveSoapButton_Click(object sender, RoutedEventArgs e)
        {
            se.SaveChanges();
            MessageBox.Show("Változtatások mentve");
        }
    }
}
