using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot_App.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserNamn { get; set; } = null!;

        public string Password { get; set; } = null!;

        //public string? Email { get; set; }
    }
}
