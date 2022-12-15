using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
    public partial class DetailsWindow : Window
    {
        private Recipe _selectedRecipe;
        RecipeRepository recipeRepo;
        TagsRepository tagsRepo;

        public DetailsWindow(Recipe recipe)
        {
            InitializeComponent();
            _selectedRecipe = recipe;

            loadIngrediens();
            loadInputs();
            desableInputs();
        }
        public void desableInputs()
        {
            txtReceptName.IsReadOnly = true;
            cbRecipeTag.IsEnabled = false;
            lvIngrediens.IsEnabled = false;
            btnChange.IsEnabled = false;
        }
        public void enableInputs()
        {
            txtReceptName.IsReadOnly = false;
            cbRecipeTag.IsEnabled = true;
            lvIngrediens.IsEnabled = true;
            btnChange.IsEnabled = true;
        }
        public void loadInputs()
        {
            if (_selectedRecipe != null)
            {
                txtReceptName.Text = _selectedRecipe.RecipeName;
                cbRecipeTag.SelectedItem = _selectedRecipe.TagName;

                using (AppDbContext context = new())
                {
                    UnitOfWork uof = new(context);
                    List<Tags> TagsList = uof.TagsRepository.GetTags();

                    foreach (Tags tags in TagsList)
                    {
                        cbRecipeTag.Items.Add(tags.TagName);
                    }
                }
            }
        }
        public void clearInputsIngredients()
        {
            txtIngrediensName.Clear();
            txtIngrediensType.Clear();
            txtIngrediensUnit.Clear();
            txtIngrediensQuantity.Clear();
        }
        private void UpdateInputs()
        {
            txtReceptName.Text = _selectedRecipe.RecipeName;
            cbRecipeTag.SelectedItem = _selectedRecipe.TagName;
        }
        public void fillInputsIngrediens()
        {
            ListViewItem item = (ListViewItem)lvIngrediens.SelectedItem;
            if(item != null)
            {
                Ingrediens selectedIngrediens = (Ingrediens)item.Tag;

                txtIngrediensName.Text = selectedIngrediens.IngrediensNamn;
                txtIngrediensType.Text = selectedIngrediens.IngredientType;
                txtIngrediensUnit.Text = selectedIngrediens.Unit;
                txtIngrediensQuantity.Text = selectedIngrediens.Quantity.ToString();
            }
            else
            {
                clearInputsIngredients();
            }
        }
        public void loadIngrediens()
        {
             if (_selectedRecipe != null)
             {
                using (AppDbContext context = new())
                {
                    Recipe? dbRecipe = context.Recipe.Include(r => r.Ingrediences).FirstOrDefault(r => r.RecipeId == _selectedRecipe.RecipeId);

                        foreach (Ingrediens ingredience in dbRecipe.Ingrediences)
                        {
                            ListViewItem item = new();
                            item.Content = $"{ingredience.IngrediensNamn}";
                            item.Tag = ingredience;
                            lvIngrediens.Items.Add(item);
                        }
                 }
             }
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recipeWindow = new(_selectedRecipe);
            recipeWindow.Show();
            this.Close();
        }

        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            //Color.Orange;
            enableInputs();
        }

        private void lvIngrediens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillInputsIngrediens();
        }

        private void btndeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
                ListViewItem item = (ListViewItem)lvIngrediens.SelectedItem;
                if (item != null)
                {
                    Ingrediens selectedIngrediens = (Ingrediens)item.Tag;
                    try
                    {
                        using (AppDbContext context = new())
                        {
                            UnitOfWork uow = new(context);

                            uow.RecipeRepo.RemoveIngredientRecipe(selectedIngrediens);
                            MessageBox.Show("The ingredient has been successfully updated!!");
                            uow.SaveChanges();
                            lvIngrediens.Items.Remove(lvIngrediens.SelectedItem);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }else {MessageBox.Show("Please click first on the recipe you want to remove");}
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            string newRecipeName = txtReceptName.Text;
            string tagToUpdate = cbRecipeTag.SelectedItem.ToString();

            _selectedRecipe.RecipeName = txtReceptName.Text;
            _selectedRecipe.TagName = tagToUpdate;

            if (!string.IsNullOrEmpty(txtReceptName.Text) && cbRecipeTag.SelectedItem != null)
            {
                try
                {
                    using (AppDbContext context = new())
                    {
                        UnitOfWork uow = new(context);
                        uow.RecipeRepo.UpdateRecipe(_selectedRecipe);
                        uow.SaveChanges();
                    }
                    MessageBox.Show("The recipe has been successfully updated!");
                    UpdateInputs();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else{ MessageBox.Show("You must fill in the gaps first!"); }

        }
}
