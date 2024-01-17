using Dominio.Interfaces.Servicos;
using Dominio.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IAutomacaoServico _servico;

        public UsuarioController(IAutomacaoServico servico)
        {
            _servico = servico;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Add(AutomacaoModelo modelo)
        {
            await _servico.Add(modelo);
            return Ok(new { Message = "Usuario cadastrado com Sucesso" });
        }

        [HttpPut]
        [Route("AtualizarDados")]
        public async Task<IActionResult> AtualizarDados(AutomacaoModelo modelo)
        {
            await _servico.AtualizarDados(modelo);
            return Ok(new { Message = "Dados atualizados com Sucesso" });
        }
        [HttpGet]
        [Route("ObterUsuarioParaPesquisa")]
        public async Task<IActionResult?> ObterUsuarioParaPesquisa(string robo)
        {
            var usuario = await _servico.ObterUsuarioParaPesquisa(robo);
            return Ok(usuario);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var usuario = await _servico.List();
            return Ok(usuario);

        }
        
    }
}