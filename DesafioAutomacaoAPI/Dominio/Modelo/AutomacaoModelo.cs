namespace Dominio.Modelo
{
    public class AutomacaoModelo
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public int Wpm { get; set; } 
        public int Keystrokes { get; set; }
        public double Accuracy { get; set; }
        public int CorrectWords { get; set; }
        public int WrongWords { get; set; }
    }
}