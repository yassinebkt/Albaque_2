using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Albaque_2.Models
{
    public class Chiffrage_Tache
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        public int ChiffrageId { get; set; }

        [Required]
        [Column(Order = 2)]
        public int TacheId { get; set; }
                
        [Required]
        public string nom { get; set; }

        [Required]
        public int ordre { get; set; }

        public virtual Tache tache { get; set; }

        public virtual Chiffrage chiffrage { get; set; }
        

    }
}