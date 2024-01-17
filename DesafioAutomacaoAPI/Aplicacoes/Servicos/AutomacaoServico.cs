using Aplicacoes.Adaptador;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Servicos;
using Dominio.Modelo;

namespace Aplicacoes.Servicos
{
    public class AutomacaoServico : IAutomacaoServico
    {
        private readonly IAutomacaoRepositorio _repositorio;

        public AutomacaoServico(IAutomacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Add(AutomacaoModelo automacao)
        {
            var dominio = AutomacaoAdaptador.Map(automacao);
            await _repositorio.Add(dominio);
        }

        public async Task AtualizarDados(AutomacaoModelo automacao)
        {
            var dominio = await _repositorio.Get(automacao.Id);
            if (dominio == null)
            {
                throw new Exception("Usuario não localizado");
            }
            dominio.Usuario = automacao.Usuario;
            dominio.Wpm = automacao.Wpm;
            dominio.Keystrokes = automacao.Keystrokes;
            dominio.Accuracy = automacao.Accuracy;
            dominio.CorrectWords = automacao.CorrectWords;
            dominio.WrongWords = automacao.WrongWords;
            dominio.Status = Dominio.Enums.EnumStatus.Finalizado;
            await _repositorio.AtualizarDados(dominio);
        }

        public async Task<List<AutomacaoModelo>> List()
        {
            var usuario = await _repositorio.List();
            return AutomacaoAdaptador.Map(usuario);
        }

        public async Task<AutomacaoModelo> ObterUsuarioParaPesquisa(string robo)
        {
            var domionio = await _repositorio.ObterUsuarioParaPesquisa(robo);
            if (domionio == null) return default;
            domionio.Status = Dominio.Enums.EnumStatus.EmAndamento;
            domionio.Robo = robo;
            await _repositorio.AtualizarDados(domionio);

            return AutomacaoAdaptador.Map(domionio);
        }
    }
}
