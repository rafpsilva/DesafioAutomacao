using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Automacao
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public int Wpm { get; set; }
        public int Keystrokes { get; set; }
        public double Accuracy { get; set; }
        public int CorrectWords { get; set; }
        public int WrongWords { get; set; }
        public EnumStatus? Status { get; set; } = EnumStatus.Aberto;
        public string? Robo { get; set; }
    }
}
