using ItauProj.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItauProj.Api.Repositories
{
    public class LancamntoFinanceiroRepository : ILancamntoFinanceiroRepository
    {
        private readonly ApplicationContext _context;

        public LancamntoFinanceiroRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public IEnumerable<LancamentoFinanceiro> GetAll() { return _context.LancamentosFinanceiros; }
        public Task<LancamentoFinanceiro> GetAsync(uint id) { return _context.LancamentosFinanceiros.FindAsync(id); }

        public async Task<LancamentoFinanceiro> InserirAsync(LancamentoFinanceiro lancamento) {
            var lancamentoSalvo = await _context.LancamentosFinanceiros.AddAsync(lancamento);
            await _context.SaveChangesAsync();
            return lancamentoSalvo.Entity;
        }
        public async Task<LancamentoFinanceiro> AlterarAsync(uint id, LancamentoFinanceiro lancamento) {
            if (id != lancamento.Id)
                throw new  ArgumentException("Registros inconsistentes");

            var lancamentoOriginal = await GetAsync(id);

            lancamentoOriginal.Tipo = lancamento.Tipo;
            lancamentoOriginal.Valor = lancamento.Valor;

            var lancamentoSalvo = _context.LancamentosFinanceiros.Update(lancamentoOriginal);
            await _context.SaveChangesAsync();
            return lancamentoSalvo.Entity;

        }
        public async Task DeletarAsync(uint id) {
             _context.LancamentosFinanceiros.Remove(await GetAsync(id));
           await  _context.SaveChangesAsync();
        }

    }

}
