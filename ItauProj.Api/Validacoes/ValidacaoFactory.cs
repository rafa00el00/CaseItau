using ItauProj.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItauProj.Api.Validacoes
{
    public static class ValidacaoFactory
    {
        public static IList<IValidacaoStrategy> ValidarDelecao(){
            return new List<IValidacaoStrategy>()
            {
                new ValidarConsolidado(),
            };
        }

        public static IList<IValidacaoStrategy> ValidarEdicao()
        {
            return new List<IValidacaoStrategy>()
            {
                new ValidarConsolidado(),
            };
        }
    }

    public interface IValidacaoStrategy
    {
        bool Validar(LancamentoFinanceiro lancamentoFinanceiro);
    }

    public class ValidarConsolidado : IValidacaoStrategy
    {
        public bool Validar(LancamentoFinanceiro lancamentoFinanceiro)
        {
            return lancamentoFinanceiro.Status == Enuns.StatusLancamentoFinanceiro.Consolidado;
        }
    }

}
