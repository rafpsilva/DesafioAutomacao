using DesafioAutomacao.Modelo;
using EasyAutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;


namespace DesafioAutomacao.Driver
{
    public class ExecucaoAutomacaoDriver : Web
    {
        public ExecucaoAutomacaoDriver()
        {
            StartBrowser();
        }
        public static string[] DividirString(string texto, string[] delimitadores)
        {
            return texto.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);
        }
        public void ExecutarTeste(AutomacaoModelo automacao)
        {
            driver.Navigate().GoToUrl("https://10fastfingers.com/typing-test/portuguese");
            try
                {
                   IWebElement button = driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection"));

                   if(button != null || button.Text != "")
                   {
                     button.Click();
                   }
                }
                catch (Exception)
                {
                    // Se o tempo limite for atingido e o alerta não estiver presente, o código continua sem erro
                }
            IWebElement textos = driver.FindElement(By.Id("row1"));
            ReadOnlyCollection<IWebElement> palavras = textos.FindElements(By.TagName("span"));
            foreach (IWebElement palavraLocalizada in palavras)
            {
                AssignValue(TypeElement.Id, "inputfield", palavraLocalizada.Text)
                .element.SendKeys(Keys.Space);
            }
            IWebElement tempo = driver.FindElement(By.Id("input-row"));
            ReadOnlyCollection<IWebElement> tempoatual = tempo.FindElements(By.TagName("div"));
            foreach(IWebElement temp in tempoatual)
            {   
                if(temp.Text != "")
                { 
                    string tp = temp.Text;
                    string[] partes = tp.Split(':');
                    int segundos = int.Parse(partes[1]);
                    int milissegundos = segundos * 1000;
                    if(milissegundos > 0)
                    Thread.Sleep(milissegundos);
                    break;
                }
            Thread.Sleep(1000);
            break;
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            IAlert alert = null;
             // Obtenha o texto do alerta, se necessário
            string textoDoAlerta = "";
            try
            {
                alert = wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch (WebDriverTimeoutException)
            {
            // Se o tempo limite for atingido e o alerta não estiver presente, o código continua sem erro
            }
            if (alert != null)
            {
                // O alerta está presente
                textoDoAlerta = alert.Text; // Obtenha o texto do alerta, se necessário
                alert.Accept(); // Clique no botão OK do alerta
            }
            
            IWebElement resultado = driver.FindElement(By.Id("result-table"));
            ReadOnlyCollection<IWebElement> corpo = resultado.FindElements(By.TagName("tbody"));
            foreach (IWebElement element in corpo)
            {   
                string[] arrayDePalavras = new string[4];
                string keystro;
                ReadOnlyCollection<IWebElement> tagTr = resultado.FindElements(By.TagName("tr"));
                foreach (IWebElement elementTr in tagTr)
                { 
                    ReadOnlyCollection<IWebElement> tagStrong = resultado.FindElements(By.TagName("strong"));
                    int i = 0;
                    foreach (IWebElement elementStrong in tagStrong)
                    {
                        string textoWpm = elementStrong.Text;
                        foreach(string palavra in arrayDePalavras)
                        {
                        arrayDePalavras[i] = textoWpm;
                        }
                        i++;
                    }         
                }
                ReadOnlyCollection<IWebElement> keystrokesTag = resultado.FindElements(By.Id("keystrokes"));
                foreach (IWebElement elementKeystrokes in keystrokesTag)
                {
                    string originalKey = elementKeystrokes.Text;
                    string[] delimitadorKey = { " " }; // Define o delimitador como espaço
                    string[] partesKey = DividirString(originalKey, delimitadorKey); 
                            
                    automacao.Keystrokes = int.Parse(partesKey[4]);
                            
                }
                    string originalWpm = arrayDePalavras[0];
                    string[] delimitadorWpm = { " " }; // Define o delimitador como espaço
                    string[] partesWpm = DividirString(originalWpm, delimitadorWpm); 
                    string originalAccuracy = arrayDePalavras[1];
                    string[] delimitadorAccuracy= { "%" }; // Define o delimitador como espaço
                    string[] partesAccuracy = DividirString(originalAccuracy, delimitadorAccuracy);         
                   
                   
                    automacao.Wpm = int.Parse(partesWpm[0]);
                    automacao.Accuracy = double.Parse(partesAccuracy[0],System.Globalization.CultureInfo.InvariantCulture);
                    automacao.CorrectWords = int.Parse(arrayDePalavras[2]);
                    automacao.WrongWords = int.Parse(arrayDePalavras[3]);    
            }
        }       
    }   
}
