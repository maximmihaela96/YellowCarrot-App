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
using System.Windows.Shapes;
using YellowCarrot_App.Data;
using YellowCarrot_App.Models;
using YellowCarrot_App.Services;

namespace YellowCarrot_App
{
    public partial class AddRecipeWindow : Window
    {
        User _signInUser;
        List<Ingrediens> receptIngrediens = new();

        public AddRecipeWindow(User signInUser)
        {
            _signInUser = signInUser;
            InitializeComponent();
            LoadTags();
            DesableRecipeInputs();
        }
        private void ClearUi()
        {
            txtReceptName.Clear();
            txtReceptIngredient.Clear();
            txtIngrediensQuantity.Clear();
            cbRecipeTag.Items.Clear();
            lvAddIngrediens.Items.Clear();
        }

        public void LoadTags() 
        {
            using (AppDbContext context = new())
            {
                List<Tags> tags = context.Tags.ToList();

                foreach (Tags tag in tags)
                {
                    ComboBoxItem item = new();
                    item.Content = tag.TagName;
                    item.Tag = tag;

                    cbRecipeTag.Items.Add(item);
                }
            }
        }
        public void DesableRecipeInputs()
        {
            txtReceptName.IsEnabled = false;
            cbRecipeTag.IsEnabled = false;
        }
        public void EnableRecipeInputs()
        {
            txtReceptName.IsEnabled = true;
            cbRecipeTag.IsEnabled = true;
        }
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = txtReceptName.Text;
            ComboBoxItem selectedItem = (ComboBoxItem)cbRecipeTag.SelectedItem;

            if (!string.IsNullOrEmpty(txtReceptName.Text) && cbRecipeTag.SelectedItem != null)
            {
                Tags selectedTags = (Tags)selectedItem.Tag;
                try
                {
                    using (AppDbContext context = new())
                    {
                        UnitOfWork uow = new(context);

                        uow.RecipeRepo.AddRecipe(new Recipe()
                        {
                            RecipeName = recipeName,
                            TagName = selectedTags.TagName,
                            Ingrediences = receptIngrediens

                        });
                        uow.SaveChanges();
                    }
                    MessageBox.Show("The recipe was added succesfully!");
                    ClearUi();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else{ MessageBox.Show("You must fill in the gaps first!");}
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recipeWindow = new(_signInUser);
            recipeWindow.Show();
            this.Close();
        }

        private void btnAddIngrediens_Click(object sender, RoutedEventArgs e)
        {
            string newIngrediensNamn = txtReceptIngredient.Text;
            int newQuantity = Int32.Parse(txtIngrediensQuantity.Text);

            if (!string.IsNullOrEmpty(txtReceptIngredient.Text) && !string.IsNullOrEmpty(txtIngrediensQuantity.Text))
            {
                Ingrediens nyIngredience = new();

                nyIngredience.IngrediensNamn = newIngrediensNamn;
                nyIngredience.Quantity = newQuantity;

                receptIngrediens.Add(nyIngredience);

                ListViewItem ingreciensReceptList = new();
                ingreciensReceptList.Content = $"Ingredient Name: {nyIngredience.IngrediensNamn} ||  Quantity: {nyIngredience.Quantity}";
                lvAddIngrediens.Items.Add(ingreciensReceptList);

                if (ingreciensReceptList != null)
                {
                    EnableRecipeInputs();
                }

            }else { MessageBox.Show("You must fill in the gaps first!"); }

            txtReceptIngredient.Clear();
            txtIngrediensQuantity.Clear();
        }

        private void lvAddIngrediens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
