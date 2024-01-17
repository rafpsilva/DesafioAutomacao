using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class AutomacaoContext : DbContext
    {
        public DbSet<Automacao> automacao { get; set; }
        public AutomacaoContext(DbContextOptions<AutomacaoContext> options) : base(options) { }
    }
}