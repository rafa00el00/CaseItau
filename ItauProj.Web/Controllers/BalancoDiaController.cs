using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ItauProj.Web.Models;
using ItauProj.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItauProj.Web.Controllers
{
    public class BalancoDiaController : Controller
    {
        private readonly IBalancoDiaService _balancoDiaService;

        public BalancoDiaController(IBalancoDiaService balancoDiaService)
        {
            this._balancoDiaService = balancoDiaService;
        }
        public async Task<IActionResult> Index()
        {
            var balanco = await _balancoDiaService.GetBalancoMesAsync(DateTime.Now.Month, DateTime.Now.Year);
            return View(balanco);
        }

        public async Task<IActionResult> Pesquisar(int mes, int ano)
        {

            var balanco = await _balancoDiaService.GetBalancoMesAsync(mes,ano);
            return View("Index", balanco);
        }
    }
}