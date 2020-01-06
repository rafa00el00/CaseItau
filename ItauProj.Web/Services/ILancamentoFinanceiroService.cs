using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItauProj.Web.Models;

namespace ItauProj.Web.Services
{
    public interface ILancamentoFinanceiroService
    {
        Task<string> DeleteLancamentoAsync(uint id);
        Task<LancamentoFinanceiro> GetLancamentoAsync(uint id);
        Task<IEnumerable<LancamentoFinanceiro>> GetLancamentosAsync(DateTime dataInicio, DateTime dataFim);
        Task<LancamentoFinanceiro> PostInserirLancamentoAsync(LancamentoFinanceiro lancamento);
        Task<LancamentoFinanceiro> PutAlterarLancamentoAsync(uint id, LancamentoFinanceiro lancamento);
    }
}