using ItauProj.Api.Bussiness;
using ItauProj.Api.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItauProj.Api.Configuration
{
    public static class ConfigureIoc
    {
        internal static void CreateIoc(IServiceCollection services)
        {
            // Repositorio
            services.AddScoped<ILancamntoFinanceiroRepository, LancamntoFinanceiroRepository>();

            //Bussines
            services.AddScoped<ILancamentoFinanceiroBo, LancamentoFinanceiroBo>();
            services.AddScoped<IBalancoDiaBo, BalancoDiaBo>();
            
        }
    }
}
