using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot_App.Models
{
    public class Ingrediens
    {
        [Key]
        public int IngrediensId { get; set; }
        public string IngrediensNamn { get; set; } = null!;
        public string? IngredientType { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }
        public Recipe? Recipe { get;  set; }
        public  int RecipeId { get; set; }  
    }
}
