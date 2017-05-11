using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albaque_2.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Nom du Client")]
        [Required]
        public string nom { get; set; }

        [Display(Name = "Addresse mail")]
        public string adresse_Mail { get; set; }

        [Display(Name = "Numero de Telephone")]
        public string numero_Tel { get; set; }


        public virtual ICollection<Projet> projets { get; set; }
    }
}