using Dominio.Entidades;
using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos
{
    public interface IAutomacaoServico
    {
        Task Add(AutomacaoModelo automacao);
        Task AtualizarDados(AutomacaoModelo automacao);
        Task<AutomacaoModelo> ObterUsuarioParaPesquisa(string robo);
        Task<List<AutomacaoModelo>> List();
    }
}
