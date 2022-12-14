using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot_App.Data;
using YellowCarrot_App.Models;

namespace YellowCarrot_App.Services
{
    internal class IngrediensRepository
    {
        private readonly AppDbContext _context;

        public IngrediensRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Ingredience> GetIngrediens()
        {
            return _context.Ingredience.ToList();
        }

        public Recipe? GetIngredience()
        {
            return null;
        }
        public void AddIngredience(Ingredience ingredienceToAdd)
        {
           // _context.Recipe.Add(ingredienceToAdd);
        }

        public void RemoveIngredience(Recipe ingredienceToRemove)
        {
            //_context.User.Remove(recipeToRemove);
        }
    }
}
