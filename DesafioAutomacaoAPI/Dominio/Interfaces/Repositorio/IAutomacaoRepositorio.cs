using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio
{
    public interface IAutomacaoRepositorio
    {
        Task Add(Automacao automacao);
        Task AtualizarDados(Automacao automacao);
        Task<Automacao> ObterUsuarioParaPesquisa(string robo);
        Task<Automacao> Get(int id);
        Task<List<Automacao>> List();
    }
}
