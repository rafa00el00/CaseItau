using System.ComponentModel;

namespace ItauProj.Api.Enuns
{
    /// <summary>
    /// Enum para tipo do lançamento financeiro
    /// </summary>
    public enum TipoLancamentoFinanceiro
    {
        [Description("Débito")]
        Debito = 0,
        [Description("Credito")]
        Credito = 1

    }
}
