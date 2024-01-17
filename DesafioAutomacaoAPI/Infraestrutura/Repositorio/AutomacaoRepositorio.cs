using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
namespace Infraestrutura.Repositorio
{
    public class AutomacaoRepositorio : IAutomacaoRepositorio
    {
        private readonly AutomacaoContext _context;
        public AutomacaoRepositorio(AutomacaoContext context)
        {
            _context = context;
        }

        public async Task Add(Automacao automacao)
        {
            await _context.AddAsync(automacao);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarDados(Automacao automacao)
        {
            _context.Update(automacao);
            await _context.SaveChangesAsync();
        }

        public async Task<Automacao?> Get(int id)
        {
            return _context.automacao.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<List<Automacao>> List()
        {
            return _context.automacao.ToList();
        }

        public async Task<Automacao> ObterUsuarioParaPesquisa(string robo)
        {
            var usuario = _context.automacao.Where(x =>
           x.Status == Dominio.Enums.EnumStatus.Aberto && string.IsNullOrEmpty(x.Robo)).FirstOrDefault();
            return usuario;
        }
    }
}
