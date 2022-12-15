using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
        public void AddRecipe(Recipe recipeToAdd)
        {
            _context.Recipe.Add(recipeToAdd);
        }
        public void RemoveRecipe(Recipe recipeToRemove)
        {
            _context.Recipe.Remove(recipeToRemove);

        }

        public void RemoveIngredientRecipe(Ingrediens selectedIngrediens)
        {
            Ingrediens? ingredienceToDelete = _context.Ingredience.FirstOrDefault(i => i.IngrediensId == selectedIngrediens.IngrediensId);
            _context.Ingredience.Remove(ingredienceToDelete);
        }

        public void UpdateRecipe(Recipe recipeToUpdate)
        {
            _context.Recipe.Update(recipeToUpdate);
        }
    }
}
