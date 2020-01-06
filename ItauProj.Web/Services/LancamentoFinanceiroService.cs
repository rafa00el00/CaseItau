using ItauProj.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItauProj.Web.Services
{
    public class LancamentoFinanceiroService : ILancamentoFinanceiroService
    {

        public async Task<IEnumerable<LancamentoFinanceiro>> GetLancamentosAsync(DateTime dataInicio, DateTime dataFim)
        {
            var sDtInicio = dataInicio.ToString("yyyy-MM-dd");
            var sDtFim = dataFim.ToString("yyyy-MM-dd");
            return await HttpHelper.GetAsync<IEnumerable<LancamentoFinanceiro>>($"{HttpHelper.GetBaseUrl()}/Lancamentofinanceiro/?dataInicio={sDtInicio}&dataFim={sDtFim}");
        }

        public async Task<LancamentoFinanceiro> GetLancamentoAsync(uint id)
        {
            return await HttpHelper.GetAsync<LancamentoFinanceiro>($"{HttpHelper.GetBaseUrl()}/Lancamentofinanceiro/{id}");
        }

        public async Task<LancamentoFinanceiro> PostInserirLancamentoAsync(LancamentoFinanceiro lancamento)
        {
            return await HttpHelper.PostAsync<LancamentoFinanceiro, LancamentoFinanceiro>($"{HttpHelper.GetBaseUrl()}/Lancamentofinanceiro/", lancamento);
        }

        public async Task<LancamentoFinanceiro> PutAlterarLancamentoAsync(uint id,LancamentoFinanceiro lancamento)
        {
            return await HttpHelper.PutAsync<LancamentoFinanceiro, LancamentoFinanceiro>($"{HttpHelper.GetBaseUrl()}/Lancamentofinanceiro/{id}", lancamento);
        }

        public async Task<string> DeleteLancamentoAsync(uint id)
        {
            return await HttpHelper.DeleteAsync($"{HttpHelper.GetBaseUrl()}/Lancamentofinanceiro/{id}");
        }

    }

    
}
