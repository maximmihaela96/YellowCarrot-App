using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot_App.Models
{
    public class Step
    {
        [Key]
        public int StepId { get; set; }
        public string Description { get; set; } = null!;
        public int? Order { get; set; }
        public int? StepTime { get; set; }
    }
}
