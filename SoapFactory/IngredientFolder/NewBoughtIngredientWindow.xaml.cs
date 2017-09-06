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
    /// Interaction logic for NewBoughtIngredientWindow.xaml
    /// </summary>
    public partial class NewBoughtIngredientWindow : Window, IDisposable
    {
        private SoapFactoryEntities se = new SoapFactoryEntities();
        private IngredientStockTable ist = new IngredientStockTable();

        public NewBoughtIngredientWindow(IngredientStockTable constructorTable)
        {
            this.ist = constructorTable;
            InitializeComponent();
            this.NewIngredientContainer.DataContext = constructorTable;
            this.ist.Date = DateTime.Now;
            this.ist.DateOfBestUse = DateTime.Now;

        }
        //Load window
        private void WindowLoadedEvent(object sender, RoutedEventArgs e)
        {
            se.IngredientTable.Load();
            this.cmbIngredient.ItemsSource = se.IngredientTable.Local;
        }

        //Cancel and go back to previous window
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        //Save changes into database
        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            se.SaveChanges();
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
