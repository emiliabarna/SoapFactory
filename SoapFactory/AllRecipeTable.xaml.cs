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
    /// Interaction logic for AllRecipeTable.xaml
    /// </summary>
    public partial class AllRecipeTable : Window, IDisposable
    {
        SoapFactoryEntities se = new SoapFactoryEntities();

        //Constructor
        public AllRecipeTable()
        {
            InitializeComponent();
        }
        //Load window and show the names of existing recipes
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            se.RecipeTable.Load();
            se.SoapTable.Load();
            se.IngredientTable.Load();
            RecipeListView.ItemsSource = (from RecipeTable in se.RecipeTable.Local
                                          select RecipeTable.Name).Distinct();
        }

        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e){}

        //Save changes into database
        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            se.SaveChanges();
        }
        //Cancel event
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Add new recipe then save into database
        private void btnNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            New_RecipeWindow nrw = new New_RecipeWindow();
            Nullable<bool> wantToSave = nrw.ShowDialog();
            if (wantToSave.HasValue && wantToSave.Value == true)
            {
                foreach (RecipeTable recipe in nrw.recipeParts)
                {
                    if (recipe != null)
                    {
                        se.RecipeTable.Add(recipe);
                    }
                }
                se.SaveChanges();
            }
            RecipeListView.ItemsSource = (from RecipeTable in se.RecipeTable.Local
                                          select RecipeTable.Name).Distinct();
        }

        //View the recipe of selected soap
        private void ViewRecipeEvent(object sender, MouseButtonEventArgs e)
        {
            se.RecipeTable.Load();
            RecipeDetails rd = new RecipeDetails();
            String searchedRecipeName = (String)(sender as ListView).SelectedItem;
            MessageBox.Show(searchedRecipeName);
            DateTime searchedRecipeDate = se.RecipeTable.Local.Where(x => x.Name == searchedRecipeName).Select(x => x.Date).First();
            String searchedRecipeOthers = se.RecipeTable.Local.Where(x => x.Name == searchedRecipeName).Select(x => x.Others).First();

            rd.RecipeDetailsDataGrid.ItemsSource = se.RecipeTable.Local.Where(x => x.Name == searchedRecipeName).ToList();
            rd.Title = searchedRecipeName + searchedRecipeDate.ToString("-yyyy-MM-DD") + searchedRecipeOthers;
            rd.ShowDialog();
        }
        public virtual void DeleteIngredient(RecipeTable entity)
        {
            //RecipeTable itemToDelete = se.RecipeTable.Local.Single(x => x.IdSoap == entity.IdSoap && x.IdIngredient == entity.IdIngredient && x.Quantity == entity.Quantity);
            //se.RecipeTable.Remove(itemToDelete);
            //se.SaveChanges();
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            se.RecipeTable.Load();

            String searchedRecipeName = (String)(RecipeListView.SelectedItem);
            int searchedRecipeId = se.RecipeTable.Where(x => x.Name == searchedRecipeName).Select(x => x.IdRecipe).First();
            MessageBox.Show(searchedRecipeId.ToString());
            se.RecipeTable.Local.Where(x => x.Name == searchedRecipeName);

            if (this.RecipeListView.SelectedItem != null)
            {
                MessageBoxResult mbr = MessageBox.Show("Biztosan törölni akarja?", "SoapStock", MessageBoxButton.YesNo,
                    MessageBoxImage.Question, MessageBoxResult.No);
                if (mbr == MessageBoxResult.Yes)
                {
                    var recipes = se.RecipeTable.Where(x => x.Name == searchedRecipeName);
                    bool result = false;
                    foreach (RecipeTable recipe in recipes)
                    {
                        if (se.SoapTable.Any(x => x.IdRecipe == recipe.IdRecipe))
                        {
                            result = true;
                        }
                    }
                    if (result == false)
                    {
                        foreach (var recipe in recipes)
                        {
                            se.RecipeTable.Remove(recipe as RecipeTable);
                        }
                        se.SaveChanges();
                        RecipeListView.ItemsSource = (from SoapTable in se.SoapTable.Local
                                                      select SoapTable.Name).Distinct();
                    }
                    else
                    {
                        MessageBox.Show("A recept nem törölhető, mivel tartozik hozzá készleten lévő termék.");
                    }
                }
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



