using System.Collections.Generic;
using System.Threading.Tasks;
using ItauProj.Api.Models;

namespace ItauProj.Api.Repositories
{
    public interface ILancamntoFinanceiroRepository
    {
        Task<LancamentoFinanceiro> AlterarAsync(uint id, LancamentoFinanceiro lancamento);
        Task DeletarAsync(uint id);
        IEnumerable<LancamentoFinanceiro> GetAll();
        Task<LancamentoFinanceiro> GetAsync(uint id);
        Task<LancamentoFinanceiro> InserirAsync(LancamentoFinanceiro lancamento);
    }
}