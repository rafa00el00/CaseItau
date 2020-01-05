using AutoMapper;
using ItauProj.Api.Models;
using ItauProj.Api.ViewModel;

namespace ItauProj.Api.Configuration
{
    public static class ConfigureAutoMapper
    {
       public static MapperConfiguration Configurar()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LancamentoFinanceiro, LancamentoFinanceiroVM>()
                    .ForMember(d => d.IdTipo, s => s.MapFrom(a => (int)a.Tipo))
                    .ForMember(d => d.DsTipo, s => s.MapFrom(a => a.Tipo.ToString()))
                .ForMember(d => d.IdStatus, s => s.MapFrom(a => (int)a.Status))
                .ForMember(d => d.DsStatus, s => s.MapFrom(a => a.Status.ToString()));

                cfg.CreateMap<LancamentoFinanceiroVM, LancamentoFinanceiro>()
                    .ForMember(d => d.Tipo, s => s.MapFrom(a => a.IdTipo))
                    .ForMember(d => d.Status, s => s.MapFrom(a => a.IdStatus));

            });
        }
    }
}
