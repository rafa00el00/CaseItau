using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ItauProj.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItauProj.Web.Controllers
{
    public class BalancoDiaController : Controller
    {
        public IActionResult Index()
        {
            
            return View(new List<BalancoDia>());
        }

        public IActionResult Pesquisar(int mes, int ano)
        {

            return View("Index", new List<BalancoDia>());
        }
    }
}