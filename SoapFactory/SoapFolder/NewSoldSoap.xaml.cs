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
    /// Interaction logic for NewSoldSoap.xaml
    /// </summary>
    public partial class NewSoldSoap : Window
    {
        SoapFactoryEntities se = new SoapFactoryEntities();
        SoapStockTable st = new SoapStockTable();

        public NewSoldSoap(SoapStockTable constructorTable)
        {
            this.st = constructorTable;
            InitializeComponent();
            this.SoapContainer.DataContext = constructorTable;
            this.st.Date = DateTime.Now;
        }

        //Load window
        private void WindowLoadedEvent(object sender, RoutedEventArgs e)
        {
            se.SoapTable.Load();
            this.cmbNames.ItemsSource = se.SoapTable.Local;
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
            this.Close();
        }  
    } 
}
