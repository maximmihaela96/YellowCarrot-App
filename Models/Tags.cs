using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot_App.Models
{
    public class Tags
    {
        [Key]
        public string TagName { get; set; } = null!;
    }
}
