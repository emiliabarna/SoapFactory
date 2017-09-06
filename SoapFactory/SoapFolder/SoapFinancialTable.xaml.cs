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
    /// Interaction logic for SoapFinancialTable.xaml
    /// </summary>
    public partial class SoapFinancialTable : Window
    {
        SoapFactoryEntities se = new SoapFactoryEntities();

        //Constructor
        public SoapFinancialTable()
        {
            InitializeComponent();
        }
        //Load window
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            se.SoapStockTable.Load();
            se.SoapTable.Load();
            this.SoapFinDataGrid.ItemsSource = se.SoapStockTable.Local;
        }

        //Go back to previous page
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //add new soap movement
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            //creating new window
            NewSoldSoap newItemPage = new NewSoldSoap(new SoapStockTable());

            //setting the properties of new item
            Nullable<bool> wantToSave = newItemPage.ShowDialog();
            if (wantToSave.HasValue && wantToSave.Value == true)
            {
                SoapStockTable newSoap = newItemPage.SoapContainer.DataContext as SoapStockTable;
                SoapTable existingIngredient = se.SoapTable.Where(x => x.IdSoap == newSoap.IdSoap).First();
                if (existingIngredient.InStock > 0)
                {
                    se.SoapStockTable.Add(newSoap);

                    //Increasing the amount of existing ingredient
                    existingIngredient.InStock -= newSoap.Quantity;
                }
                else
                {
                    MessageBox.Show("A választott szappan elkészítéséhez nincs elegendő alapanyag");
                }
            }

            //se.FinancialTable.Add(new FinancialTable() {IsSelling=true, Amount = newSoap.Profit});
        }


        //Save database
        private void SaveSoapButton_Click(object sender, RoutedEventArgs e)
        {
            se.SaveChanges();
            MessageBox.Show("Változtatások mentve");
        }
    }
}
