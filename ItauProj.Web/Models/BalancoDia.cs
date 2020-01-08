using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItauProj.Web.Models
{
    public class BalancoDia
    {
        public DateTime DataBalancio { get; set; }
        public double ValorTotalCredito { get; set; }
        public double ValorTotalDebito { get; set; }
        public double ValorSaldo { get {
                return ValorTotalCredito + ValorTotalDebito;
            } }

    }
}
