using AutoMapper;
using ItauProj.Api.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItauProj.Api.ViewModel
{
    public class LancamentoFinanceiroVM
    {
        public uint Id { get; set; }
        public DateTime DtHrLancamento { get; set; }

        public double Valor { get; set; }
        public uint IdTipo { get; set; }
        public string DsTipo { get; set; }
        public uint IdStatus { get; set; }
        public string DsStatus { get; set; }

    }
}
