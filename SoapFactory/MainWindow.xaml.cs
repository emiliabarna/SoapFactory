using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoapFactory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
        }

        //Opens soap window
        private void ToSoapStock(object sender, RoutedEventArgs e)
        {
            SoapStock stw = new SoapStock();
            stw.ShowDialog();
        }
        //Opens recipe window
        private void ToRecipes_Click(object sender, RoutedEventArgs e)
        {
            AllRecipeTable rt= new AllRecipeTable();
           rt.ShowDialog();
        }
        //Opens ingredient window
        private void ToIngredientStockButton_Click(object sender, RoutedEventArgs e)
        {
            IngredientStockWindow iw = new IngredientStockWindow();
            iw.ShowDialog();
        }

        //Opens soap financial window
        private void ToSoapSellWindow(object sender, RoutedEventArgs e)
        {
            SoapFinancialTable ifw = new SoapFinancialTable();
            ifw.ShowDialog();
        }
        //Opens ingredient financial window
        private void ToIngredientSellWindow(object sender, RoutedEventArgs e)
        {
           IngredientFinancialTable ifw = new IngredientFinancialTable();
            ifw.ShowDialog();
        }

        private void ToFinancialSellWindow(object sender, RoutedEventArgs e)
        {
            FinancialWindow ft = new FinancialWindow();
            ft.ShowDialog();
        }
    }
}
