using ItauProj.Web.Enuns;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ItauProj.Web.Models
{
    /// <summary>
    /// Classe Lançamento Financeiro
    /// </summary>
    public class LancamentoFinanceiro
    {
        [HiddenInput(DisplayValue = true)]
        public uint Id { get; set; }

        /// <summary>
        /// Data e hora do lançamento
        /// </summary>
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DtHrLancamento { get; set; }

        /// <summary>
        /// Valor efetuado do lançamento
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }
        
        /// <summary>
        /// Tipo do lançamento
        /// </summary>
        [Required]
        [EnumDataType(typeof(TipoLancamentoFinanceiro))]
        public TipoLancamentoFinanceiro Tipo { get; set; }

        /// <summary>
        /// Status do lançamento
        /// </summary>
        [Required]
        [EnumDataType(typeof(StatusLancamentoFinanceiro))]
        public StatusLancamentoFinanceiro Status { get; set; }
    }
}
