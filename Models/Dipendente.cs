using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _26FebbraioEs.Models
{
    public class Dipendente
    {
       
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string CodiceFiscale { get; set; }
        public bool Coniugato { get; set; }
        public int FigliACarico { get; set; }
        public string Mansione { get; set; }

    }
}