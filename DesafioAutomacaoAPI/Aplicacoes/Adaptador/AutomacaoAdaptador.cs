using Dominio.Entidades;
using Dominio.Modelo;


namespace Aplicacoes.Adaptador
{
    public class AutomacaoAdaptador
    {
        public static AutomacaoModelo Map(Automacao automacao)
        {
            var model = new AutomacaoModelo();
            model.Id = automacao.Id;
            model.Usuario = automacao.Usuario;
            model.Wpm = automacao.Wpm;
            model.Keystrokes = automacao.Keystrokes;
            model.Accuracy = automacao.Accuracy;
            model.CorrectWords = automacao.CorrectWords;
            model.WrongWords = automacao.WrongWords;


            return model;
        }

        public static Automacao Map(AutomacaoModelo automacao)
        {
            var model = new Automacao();
            model.Id = automacao.Id;
            model.Usuario = automacao.Usuario;
            model.Wpm = automacao.Wpm;
            model.Keystrokes = automacao.Keystrokes;
            model.Accuracy = automacao.Accuracy;
            model.CorrectWords = automacao.CorrectWords;
            model.WrongWords = automacao.WrongWords;

            return model;
        }

        public static List<AutomacaoModelo> Map(List<Automacao> automacao)
        {
            return automacao.Select(Map).ToList();
        }
        public static List<Automacao> Map(List<AutomacaoModelo> automacao)
        {
            return automacao.Select(Map).ToList();
        }
    }
}
