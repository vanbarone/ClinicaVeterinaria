using System;
using System.Reflection.Metadata.Ecma335;

namespace ClinicaVeterinaria.Models
{
    public class Consultas
    {

        public int id { get; set; }

        public Animais animais { get; set; }

        public Veterinarios veterinarios { get; set; }

        public DateTime data { get; set; }

        public double peso { get; set; }

        public string sintomas { get; set; }

        public string diagnostico { get; set; }

        public double valor { get; set; }
    }
}
