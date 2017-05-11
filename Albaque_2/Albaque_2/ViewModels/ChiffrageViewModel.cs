using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Albaque_2.Models;

namespace Albaque_2.ViewModels
{
    public class ChiffrageViewModel
    {
        public IEnumerable<Projet> projets { get; set; }
        public Chiffrage Chiffrage { get; set; }
        public IEnumerable<Chiffrage_Tache> ChiffrageTaches { get; set; }
        public IEnumerable<Tache> taches { get; set; }
        public Tache tache { get; set; }
        public double TotalCharge { get; set; }
    }
}