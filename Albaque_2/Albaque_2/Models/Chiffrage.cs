using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque_2.Models
{
    public class Chiffrage
    {
        public int Id { get; set; }

        [Display(Name = "Nom du Projet")]
        [Required]
        public int ProjetId { get; set; }

        [Display(Name = "Nom d'utilisateur")]
        [Required]
        public string UserId { get; set; }

        [Display(Name = "Nom du chiffrage")]
        [Required]
        public string nom { get; set; }

        [Display(Name = "Version")]
        public string version { get; set; }

        [Display(Name = "Date de creation")]
        [Required]
        public DateTime Date_Creation { get; set; }


        public Projet projet { get; set; }

        public virtual ICollection<Chiffrage_Tache> chiffrageTache { get; set; }

    }
}