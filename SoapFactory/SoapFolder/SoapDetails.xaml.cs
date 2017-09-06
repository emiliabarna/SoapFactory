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
    /// Interaction logic for SoapDetails.xaml
    /// </summary>
    public partial class SoapDetails : Window
    {
        private SoapFactoryEntities se = new SoapFactoryEntities();
        private SoapTable st = new SoapTable();

        //Constructor for setting properties
        public SoapDetails(SoapTable s)
        {
            this.st = s;
            InitializeComponent();
            this.DataContext = this.st;
            this.st.BestBeforeDate = DateTime.Now;
            this.st.TimeOfProduction = DateTime.Now;
            this.st.TimeOfReadyToUse = DateTime.Now;

        }
        //Load window and set the combobox with existing recipenames
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            se.RecipeTable.Load();
            se.SoapTable.Load();
            this.cmbRecipesAvailable.ItemsSource = se.RecipeTable.Local.GroupBy(x => x.Name).ToList();
        }
        //Save changes to database
        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Check if every field is filled out
           SoapTable dateOfProduce = this.DateOfProduce.DataContext as SoapTable;
           SoapTable dateOfReady =this.DateOfReady.DataContext as SoapTable;
            SoapTable dateOfBestBefore =this.DateOfBestBefore.DataContext as SoapTable;
            SoapTable name = this.NameBox.DataContext as SoapTable;
            SoapTable recipe = this.cmbRecipesAvailable.DataContext as SoapTable;
   
            // Validation - Check if every field is filled out
            if (
                       name.Name == null
                       || dateOfBestBefore.BestBeforeDate < dateOfProduce.TimeOfProduction
                       || dateOfBestBefore.BestBeforeDate < dateOfReady.TimeOfReadyToUse
                       || dateOfReady.TimeOfReadyToUse < dateOfProduce.TimeOfProduction
                       || recipe.IdRecipe == 0
                       )
            {
                MessageBox.Show("Minden mezőt szükséges kitölteni.");
            }
            else
            {
                this.DialogResult = true;
                this.Close();
            }
        }
        //Cancel button
        private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
                this.DialogResult = false;
                this.Close();
            }
        }
    }
