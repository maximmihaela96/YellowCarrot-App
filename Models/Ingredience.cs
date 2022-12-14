using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot_App.Models
{
    public class Ingredience
    {
        [Key]
        public int IngredienceId { get; set; }
        public string IngredienceNamn { get; set; } = null!;
        public string? IngredientType { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }
        public Recipe? Recipe { get;  set; }
        public  int RecipeId { get; set; }  
    }
}
