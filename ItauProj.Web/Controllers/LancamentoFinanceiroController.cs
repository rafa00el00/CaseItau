using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItauProj.Web.Models;
using ItauProj.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItauProj.Web.Controllers
{
    public class LancamentoFinanceiroController : Controller
    {
        private readonly ILancamentoFinanceiroService _lancamentoFinanceiroService;

        public LancamentoFinanceiroController(ILancamentoFinanceiroService lancamentoFinanceiroService )
        {
            this._lancamentoFinanceiroService = lancamentoFinanceiroService;
        }
        // GET: LancamentoFinanceiro
        public async Task<ActionResult> Index()
        {
            var response = await _lancamentoFinanceiroService.GetLancamentosAsync(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month , DateTime.Now.Day));

            return View(response);
        }

        [HttpPost]
        [Route("Pesquisar")]
        public async Task<ActionResult> Pesquisar(DateTime dtInicio, DateTime dtFim)
        {
            var response = await _lancamentoFinanceiroService.GetLancamentosAsync(dtInicio,dtFim);

            return View("Index",response);
        }

        // GET: LancamentoFinanceiro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LancamentoFinanceiro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LancamentoFinanceiro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)
                    return BadRequest("Modelo invalido");

                var lancamento = new LancamentoFinanceiro
                {
                    DtHrLancamento = DateTime.Now,
                    Status = Enuns.StatusLancamentoFinanceiro.NaoConsolidado,
                    Tipo = (Enuns.TipoLancamentoFinanceiro)int.Parse(collection["tipo"]),
                    Valor = double.Parse(collection["valor"])
                };
                await _lancamentoFinanceiroService.PostInserirLancamentoAsync(lancamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LancamentoFinanceiro/Edit/5
        public async Task<ActionResult> Edit(uint id)
        {
            var lancamento = await _lancamentoFinanceiroService.GetLancamentoAsync(id);
            return View(lancamento);
        }

        // POST: LancamentoFinanceiro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(uint id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                var lancamento = new LancamentoFinanceiro
                {
                    Id =id,
                    DtHrLancamento = DateTime.Now,
                    Status = Enuns.StatusLancamentoFinanceiro.NaoConsolidado,
                    Tipo = (Enuns.TipoLancamentoFinanceiro)int.Parse(collection["tipo"]),
                    Valor = double.Parse(collection["valor"].ToString().Replace('.',','),System.Globalization.NumberStyles.AllowCurrencySymbol | System.Globalization.NumberStyles.Currency | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.Float)
                };
                await _lancamentoFinanceiroService.PutAlterarLancamentoAsync(id,lancamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LancamentoFinanceiro/Delete/5
        public async Task<ActionResult> Delete(uint id)
        {
            var lancamento = await _lancamentoFinanceiroService.DeleteLancamentoAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: LancamentoFinanceiro/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(uint id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var lancamento = new LancamentoFinanceiro
                {
                    Id = id,
                    DtHrLancamento = DateTime.Now,
                    Status = Enuns.StatusLancamentoFinanceiro.NaoConsolidado,
                    Tipo = (Enuns.TipoLancamentoFinanceiro)int.Parse(collection["tipo"]),
                    Valor = double.Parse(collection["valor"])
                };
                await _lancamentoFinanceiroService.PutAlterarLancamentoAsync(id,lancamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}