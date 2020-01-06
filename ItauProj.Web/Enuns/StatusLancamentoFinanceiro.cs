using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ItauProj.Web.Enuns
{

    /// <summary>
    /// Enum para status do lançamento financeiro
    /// </summary>
    public enum StatusLancamentoFinanceiro
    {
        [Description("Não Consolidado")]
        NaoConsolidado = 0,
        [Description("Consolidado")]
        Consolidado = 1

    }
}
