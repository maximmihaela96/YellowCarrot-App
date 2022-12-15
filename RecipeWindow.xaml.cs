using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Xml;
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
using YellowCarrot_App.Data;
using YellowCarrot_App.Models;
using YellowCarrot_App.Services;

namespace YellowCarrot_App
{
    public partial class RecipeWindow : Window
    {
        private User? _signInUser;
        RecipeRepository recipeRepo;
        IngrediensRepository ingredienceRepo;
        private Recipe selectedRecipe;

        public RecipeWindow(User signInUser)
        {
            InitializeComponent();
            _signInUser = signInUser;
            lblUserName.Content = _signInUser.UserNamn;
            

            using (AppDbContext context = new())
            {
                recipeRepo = new RecipeRepository(context);
                ingredienceRepo = new IngrediensRepository(context);

                TagsRepository tagRepo = new TagsRepository(context);
                LoadRecept();
            }
        }
        public RecipeWindow(Recipe selectedRecipe)
        {
            this.selectedRecipe = selectedRecipe;
        }

        public void LoadRecept() 
        {
                using (AppDbContext context = new())
                {

                    UnitOfWork uof = new(context);
                    List<Recipe> recipeList = uof.RecipeRepo.GetRecipes();
                        foreach (Recipe recipe in recipeList)
                        {
                            ListViewItem item = new();
                            item.Content = $"{ recipe.RecipeName}";
                            item.Tag = recipe;
                            lvRecipe.Items.Add(item); 
                        }
                }
        }
        private void lvRecipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnRecipeDetails_Click(object sender, RoutedEventArgs e)
        {
            if (lvRecipe.SelectedItem != null)
            {
                ListViewItem selectedListViewItem = (ListViewItem)lvRecipe.SelectedItem;
                Recipe selectedRecipe = (Recipe)selectedListViewItem.Tag;
                DetailsWindow recipeDetailsWindow = new(selectedRecipe);
                recipeDetailsWindow.Show();
            }
            else
            {
                MessageBox.Show("To be able to see the recipe details, you must first select the recipe from the list");
            }
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(_signInUser);
            this.Close();
            addRecipeWindow.Show();
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            this.Close();
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {

            if (lvRecipe_SelectionChanged != null)
            {
                ListViewItem item = (ListViewItem)lvRecipe.SelectedItem;
                Recipe selectedRecipe = (Recipe)item.Tag;

                var result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (AppDbContext context = new())
                        {
                            UnitOfWork uow = new(context);

                            // uow.IngredienceRepo.RemoveIngredience(selectedRecipe);
                            uow.RecipeRepo.RemoveRecipe(selectedRecipe);
                            MessageBox.Show("The recipe has been succesfully deleted!");
                            uow.SaveChanges();
                            lvRecipe.Items.Remove(lvRecipe.SelectedItem);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }else{MessageBox.Show("Come back when you want to delete them!");}
            }else{   MessageBox.Show("Please click first on the recipe you want to remove");  }
        }
    }
}
