using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque_2.Models
{
    public class Tache
    {
        public int Id { get; set; }

        [Display(Name = "Categorie")]
        [Required]
        public int CategorieId { get; set; }

        [Display(Name = "Complexite")]
        [Required]
        public int ComplexiteId { get; set; }

        [Display(Name = "Technologie")]
        [Required]
        public int TechnologieId { get; set; }

        [Display(Name = "Nom de la Tache")]
        [Required]
        public string nom { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Charge")]
        public double charge { get; set; }


        public virtual Categorie categorie { get; set; }

        public virtual Complexite complexite { get; set; }

        public virtual Technologie technologie { get; set; }

        public virtual ICollection<Chiffrage_Tache> chiffrageTache { get; set; }
    }
}