using AutoMapper;
using ItauProj.Api.Models;
using ItauProj.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ItauProj.Api.Bussiness
{
    public class BalancoDiaBo : IBalancoDiaBo
    {
        private readonly ILancamntoFinanceiroRepository _lancamntoFinanceiroRepository;
        private readonly IMapper _mapper;


        public BalancoDiaBo(ILancamntoFinanceiroRepository lancamntoFinanceiroRepository, IMapper mapper)
        {
            this._lancamntoFinanceiroRepository = lancamntoFinanceiroRepository;
            this._mapper = mapper;
        }


        public IEnumerable<BalancoDia> GetBalancoMes(int mes, int ano)
        {
            var lancamentosmes = _lancamntoFinanceiroRepository.GetAll()
                    .Where(l => l.DtHrLancamento >= new DateTime(ano, mes, 1))
                    .Where(l => l.DtHrLancamento <= new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes)));

            var diasTotais = Enumerable.Range(1, DateTime.DaysInMonth(ano, mes))
                .Select(e => new LancamentoFinanceiro() { DtHrLancamento = new DateTime(ano, mes, e) });
                //GroupBy( e => e, e => new { debito = 0d , credito = 0d }) ;

            return lancamentosmes
                .Union(diasTotais)
                .GroupBy(
                    l => l.DtHrLancamento.Day,
                    e => new { debito = e.Tipo == Enuns.TipoLancamentoFinanceiro.Debito ? e.Valor : 0, credito = e.Tipo == Enuns.TipoLancamentoFinanceiro.Credito ? e.Valor : 0 })
                    .Select((v,k) => new BalancoDia { DataBalancio = new DateTime(ano, mes, k), ValorTotalCredito = v.Sum(e => e.credito), ValorTotalDebito = v.Sum(e => e.debito) })
                    ;


        }
    }
}
