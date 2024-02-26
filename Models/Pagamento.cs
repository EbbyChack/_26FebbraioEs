using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _26FebbraioEs.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int IdDipendente { get; set; }
        public DateTime PeriodoPagamento { get; set; }
        public decimal Ammontare {  get; set; }
        public string TipoPagamento { get; set; }

    }
}