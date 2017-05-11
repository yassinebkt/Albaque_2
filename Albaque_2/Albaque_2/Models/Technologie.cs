using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque_2.Models
{
    public class Technologie
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required]
        public string nom { get; set; }
    }
}