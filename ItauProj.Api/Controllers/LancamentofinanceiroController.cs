using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItauProj.Api.Bussiness;
using ItauProj.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItauProj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentofinanceiroController : ControllerBase
    {
        private readonly ILancamentoFinanceiroBo _lancamentoFinanceiroBo;

        public LancamentofinanceiroController(ILancamentoFinanceiroBo lancamentoFinanceiroBo)
        {
            this._lancamentoFinanceiroBo = lancamentoFinanceiroBo;
        }

        [HttpPost]
        public async Task<IActionResult> CadastroLancamentoAsync(LancamentoFinanceiro lancamentoFinanceiro) {
            return Ok(await _lancamentoFinanceiroBo.InserirAsync(lancamentoFinanceiro));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EdicaoLancamentoAsync([FromRoute]uint id, [FromBody] LancamentoFinanceiro lancamentoFinanceiro) {
            try
            {
                return Ok(await _lancamentoFinanceiroBo.AlterarAsync(id, lancamentoFinanceiro));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DelecaoLancamentoAsync([FromRoute]uint id)
        {
            try
            {
                await _lancamentoFinanceiroBo.DeletarAsync(id);
                return Ok("Lançamento Deletado");
            }
            catch (Exception ex)
            {
                return BadRequest("Lançamento não atualizado");
            }
        }
        [HttpGet]
        public IActionResult ConsultaLancamento([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim) {
            return Ok(_lancamentoFinanceiroBo.GetAll(dataInicio,dataFim));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ConsultaLancamentoAsync([FromRoute] uint id)
        {
            return Ok(await _lancamentoFinanceiroBo.GetAsync(id));
        }

        //public IActionResult ConsolidacaoDiaria() { throw new NotImplementedException(); }

        [HttpGet]
            [Route("Relatorio")]
        public IActionResult RelatorioBalancoMensal() { throw new NotImplementedException(); }

    }
}