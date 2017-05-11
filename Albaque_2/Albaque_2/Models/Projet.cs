using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Albaque_2.Models
{
    public class Projet
    {
        public int Id { get; set; }

        [Display(Name = "Nom du client")]
        [Required]
        public int ClientId { get; set; }

        [Display(Name = "Nom du projet")]
        [Required]
        public string Nom { get; set; }

        [Display(Name = "Durée")]
        public double Duree { get; set; }

        [Display(Name = "Delai")]
        public double Delai { get; set; }

        [Display(Name = "Date de debut")]
        [Required]
        public DateTime Date_Debut { get; set; }

        [Display(Name = "Date de fin")]
        public DateTime Date_Fin { get; set; }

        public virtual Client client { get; set; }

        public virtual ICollection<Chiffrage> chiffrage { get; set; }
    }
}