using System;
using System.Collections.Generic;
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
    /// Interaction logic for SoapPage.xaml
    /// </summary>
    public partial class NewIngredientPage : Window, IDisposable
    {
        private SoapFactoryEntities se = new SoapFactoryEntities();
        private IngredientTable it = new IngredientTable();

        //Add new ingredient
        public NewIngredientPage()
        {
            InitializeComponent();
            this.DataContext = this.it;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) { }

        //Go back to previous page
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        //Save changes into database
        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            //Validation - Check if name is given
            IngredientTable newIngredient = this.NewIngName.DataContext as IngredientTable;
            if (newIngredient.Name == null)
            {
                MessageBox.Show("Kérem adja meg az új alapanyag nevét.");
            }
            else
            {
                this.DialogResult = true;
                this.Close();
            }
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
