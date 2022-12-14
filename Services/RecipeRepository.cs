using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot_App.Data;
using YellowCarrot_App.Models;

namespace YellowCarrot_App.Services
{
    class RecipeRepository
    {
        private readonly AppDbContext _context;

        public RecipeRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Recipe> GetRecipes()
        {
            return _context.Recipe.ToList();
        }

        public Recipe? GetRecipe()
        {
            return null;
        }

       /* public void AddDefaultRecipe()
        {

            _context.Recipe.Add(new Recipe()
                {
                    RecipeName = "Muffins",
                    TagName = "Desert"
                });

            _context.SaveChanges();
        }
       */
        public void AddRecipe(Recipe recipeToAdd)
        {
            _context.Recipe.Add(recipeToAdd);
        }

        public void RemoveRecipe(Recipe recipeToRemove)
        {
            //_context.User.Remove(recipeToRemove);
        }

    }
}
