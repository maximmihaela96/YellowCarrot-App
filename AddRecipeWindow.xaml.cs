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
        public AddRecipeWindow()
        {
            InitializeComponent();
            LoadTags();
        }

        private void ClearUi()
        {
            txtReceptName.Clear();
            txtReceptIngredienser.Clear();
            txtIngrediensQuantity.Clear();
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

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = txtReceptName.Text;
            ComboBoxItem selectedItem = (ComboBoxItem)cbRecipeTag.SelectedItem;
            Tags selectedTags = (Tags)selectedItem.Tag;

            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);

                uow.RecipeRepo.AddRecipe(new Recipe()
                {
                    RecipeName = recipeName,
                    TagName = selectedTags.TagName
                }) ;

                uow.SaveChanges();

                ClearUi();
            }
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            //RecipeWindow recipeWindow = new();
            //recipeWindow.Show();
           // this.Close();
        }
    }
}
