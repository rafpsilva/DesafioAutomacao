using DesafioAutomacao;
using DesafioAutomacao.Driver;
using DesafioAutomacao.Modelo;
using org.bouncycastle.asn1.ocsp;

const string BASE_URL = "http://localhost:5046/Usuario/";

var request = new RequestProvider();
var buscar = new ExecucaoAutomacaoDriver();
while (true)
     {
     var automacao = await request.GetAsync<AutomacaoModelo>(BASE_URL + "ObterUsuarioParaPesquisa?robo=robot");
     if (automacao != null && !string.IsNullOrEmpty(automacao.Usuario))

   
    buscar.ExecutarTeste(automacao);

         await request.PutAsync(BASE_URL + "AtualizarDados", automacao);
     
    Thread.Sleep(TimeSpan.FromSeconds(5));
}