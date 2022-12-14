using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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
        public RecipeWindow(User signInUser)
        {
            InitializeComponent();
            this._signInUser = signInUser;
            lblUserName.Content = _signInUser.UserNamn;

            using (AppDbContext context = new())
            {
                 recipeRepo = new RecipeRepository(context);
               // recipeRepo.AddDefaultRecipe();

                TagsRepository tagRepo = new TagsRepository(context);
                // tagRepo.AddDefaultTags();
                LoadRecept();
            }
        }

        public void LoadRecept()
        
            {
                using (AppDbContext context = new())
                {
                    List<Recipe> recipeList = recipeRepo.GetRecipes();
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

        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
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
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow();
            this.Close();
            addRecipeWindow.Show();
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            this.Close();
        }
    }
}
