using Aplicacoes.Servicos;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Servicos;
using Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace API.IOC
{
    public static class DI
    {
        public static void AddSdk(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAutomacaoServico, AutomacaoServico>();
            services.AddScoped<IAutomacaoRepositorio, AutomacaoRepositorio>();
            services.AddDbContext<AutomacaoContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
