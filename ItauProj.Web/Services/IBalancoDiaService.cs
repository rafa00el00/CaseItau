using System.Collections.Generic;
using System.Threading.Tasks;
using ItauProj.Web.Models;

namespace ItauProj.Web.Services
{
    public interface IBalancoDiaService
    {
        Task<IEnumerable<BalancoDia>> GetBalancoMesAsync(int mes, int ano);
    }
}