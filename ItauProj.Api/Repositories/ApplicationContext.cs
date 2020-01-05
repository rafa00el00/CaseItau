using ItauProj.Api.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ItauProj.Api.Repositories
{
    public class ApplicationContext : DbContext
    {

        public DbSet<LancamentoFinanceiro> LancamentosFinanceiros { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }
    }

}
