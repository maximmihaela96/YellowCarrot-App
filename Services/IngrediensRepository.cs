using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
      /*  public List<Ingrediens> GetIngrediens()
        {
            return _context.Ingredience.ToList();
        }
      */

        public void RemoveIngredience(Recipe ingredienceToRemove)
        {
            //   Ingrediens? ingredienceToDelete = _context.Ingredience.Include(r => r.RecipeId).First(i => i.RecipeId == ingredienceToRemove.RecipeId);
            Ingrediens? ingredienceToDelete = _context.Ingredience.FirstOrDefault(i => i.RecipeId == ingredienceToRemove.RecipeId);
            if (ingredienceToDelete != null)
            {
                _context.Ingredience.Remove(ingredienceToDelete);

            }
            else
            {

            }
         
        }
    }
}
