using Microsoft.EntityFrameworkCore;
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
        IngrediensRepository ingrediensRepo;

        public DetailsWindow(Recipe recipe)
        {
            InitializeComponent();
            _selectedRecipe = recipe;
            loadIngrediens();
        }


        public void loadIngrediens()
        {
           // List<Ingredience> ingredienceList = ingrediensRepo.GetIngrediens();

            using (AppDbContext context = new())
            {
                Recipe? dbRecipe = context.Recipe.Include(r => r.Ingrediences).FirstOrDefault(r => r.RecipeId == _selectedRecipe.RecipeId);

                foreach (Ingredience ingredience in dbRecipe.Ingrediences)
                {
                    ListViewItem item = new();
                    item.Content = $"{ingredience.IngredienceNamn}";
                    item.Tag = ingredience;
                    lvIngrediens.Items.Add(item);
                }
            }
        }
    }
}
