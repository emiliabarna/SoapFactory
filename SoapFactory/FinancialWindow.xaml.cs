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
    /// Interaction logic for FinancialWindow.xaml
    /// </summary>
    public partial class FinancialWindow : Window
    {
        SoapFactoryEntities se = new SoapFactoryEntities();

        public FinancialWindow()
        {
            InitializeComponent();
        }
        //Load window
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            se.FinancialTable.Load();
            this.FinancialDataGrid.ItemsSource = se.FinancialTable.Local;
        }

        //go back to previous window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
