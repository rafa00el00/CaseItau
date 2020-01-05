using AutoMapper;
using ItauProj.Api.Models;
using ItauProj.Api.Repositories;
using ItauProj.Api.Validacoes;
using ItauProj.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItauProj.Api.Bussiness
{
    public class LancamentoFinanceiroBo : ILancamentoFinanceiroBo
    {
        private readonly ILancamntoFinanceiroRepository _lancamntoFinanceiroRepository;
        private readonly IMapper _mapper;

        public LancamentoFinanceiroBo(ILancamntoFinanceiroRepository lancamntoFinanceiroRepository, IMapper mapper)
        {
            this._lancamntoFinanceiroRepository = lancamntoFinanceiroRepository;
            this._mapper = mapper;
        }

        public async Task<LancamentoFinanceiroVM> AlterarAsync(uint id, LancamentoFinanceiro lancamento)
        {
            var lancamentoFinanceiro = await _lancamntoFinanceiroRepository.GetAsync(id);
            var isInvalid = false;
            foreach (var validacao in ValidacaoFactory.ValidarDelecao())
            {
                isInvalid = isInvalid || validacao.Validar(lancamentoFinanceiro);
            }

            if (isInvalid)
                throw new Exception("Operação invalida");

            return _mapper.Map<LancamentoFinanceiroVM>(await _lancamntoFinanceiroRepository.AlterarAsync(id, lancamento));
        }
        public async Task DeletarAsync(uint id)
        {
            var lancamentoFinanceiro = await _lancamntoFinanceiroRepository.GetAsync(id);
            var isInvalid = false;
            foreach (var validacao in ValidacaoFactory.ValidarDelecao())
            {
                isInvalid = isInvalid || validacao.Validar(lancamentoFinanceiro);
            }

            if (isInvalid)
                throw new Exception("Operação invalida");

            await _lancamntoFinanceiroRepository.DeletarAsync(id);
        }
        public IEnumerable<LancamentoFinanceiroVM> GetAll(DateTime dataInicio,DateTime dataFim)
        {
            return _mapper.Map< IEnumerable<LancamentoFinanceiroVM>>(
                    _lancamntoFinanceiroRepository.GetAll()
                        .Where(l => l.DtHrLancamento > dataInicio.Date.AddHours(0).AddMinutes(0).AddSeconds(0))
                        .Where(l => l.DtHrLancamento < dataFim.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                    );
        }
        public async Task<LancamentoFinanceiroVM> GetAsync(uint id)
        {
            return _mapper.Map<LancamentoFinanceiroVM>(await _lancamntoFinanceiroRepository.GetAsync(id));
        }
        public async Task<LancamentoFinanceiroVM> InserirAsync(LancamentoFinanceiro lancamento)
        {
            return _mapper.Map<LancamentoFinanceiroVM>(await _lancamntoFinanceiroRepository.InserirAsync(lancamento));
        }
    }
}
