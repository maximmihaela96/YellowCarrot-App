using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot_App.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public string RecipeName { get; set; } = null!;
        public string? InfoRecept { get; set; }
        public int? PreparingTime { get; set; }
        public string? SkillLevel { get; set; }
        public string? TagName { get; set; }
        public List<Ingredience>? Ingrediences { get; set; } = new();
        public List<Step>? Steps { get; set; } = new();

    }
}
