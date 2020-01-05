using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItauProj.Api.Models;
using ItauProj.Api.ViewModel;

namespace ItauProj.Api.Bussiness
{
    public interface ILancamentoFinanceiroBo
    {
        Task<LancamentoFinanceiroVM> AlterarAsync(uint id, LancamentoFinanceiro lancamento);
        Task DeletarAsync(uint id);
        IEnumerable<LancamentoFinanceiroVM> GetAll(DateTime dataInicio, DateTime dataFim);
        Task<LancamentoFinanceiroVM> GetAsync(uint id);
        Task<LancamentoFinanceiroVM> InserirAsync(LancamentoFinanceiro lancamento);
    }
}