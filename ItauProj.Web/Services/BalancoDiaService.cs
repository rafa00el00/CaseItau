using ItauProj.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItauProj.Web.Services
{
    public class BalancoDiaService : IBalancoDiaService
    {
        public async Task<IEnumerable<BalancoDia>> GetBalancoMesAsync(int mes,int ano)
        {
            
            return await HttpHelper.GetAsync<IEnumerable<BalancoDia>>($"{HttpHelper.GetBaseUrl()}/BalancoDia/?mes={mes}&ano={ano}");
        }
    }

    
}
