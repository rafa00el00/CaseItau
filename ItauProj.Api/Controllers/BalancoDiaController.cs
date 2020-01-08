using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItauProj.Api.Bussiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItauProj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancoDiaController : ControllerBase
    {
        private readonly IBalancoDiaBo _balancoDiaBo;

        public BalancoDiaController(IBalancoDiaBo balancoDiaBo)
        {
            this._balancoDiaBo = balancoDiaBo;
        }


        [HttpGet]
        public IActionResult GetBalancoDia([FromQuery] int mes, [FromQuery] int ano)
        {
            return Ok(_balancoDiaBo.GetBalancoMes(mes, ano));
        }
    }
}