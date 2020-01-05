using ItauProj.Api.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItauProj.Api.Models
{
    /// <summary>
    /// Classe Lançamento Financeiro
    /// </summary>
    public class LancamentoFinanceiro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public double Valor { get; set; }

        /// <summary>
        /// Tipo do lançamento
        /// </summary>
        [Required]
        public TipoLancamentoFinanceiro Tipo { get; set; }

        /// <summary>
        /// Status do lançamento
        /// </summary>
        [Required]
        public StatusLancamentoFinanceiro Status { get; set; }
    }
}
