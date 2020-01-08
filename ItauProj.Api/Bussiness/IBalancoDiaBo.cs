using System.Collections.Generic;
using ItauProj.Api.Models;

namespace ItauProj.Api.Bussiness
{
    public interface IBalancoDiaBo
    {
        IEnumerable<BalancoDia> GetBalancoMes(int mes, int ano);
    }
}