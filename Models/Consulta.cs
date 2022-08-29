using System;
using System.Reflection.Metadata.Ecma335;

namespace ClinicaVeterinaria.Models
{
    public class Consulta
    {

        public int id { get; set; }

        public Animal animais { get; set; }

        public Veterinario veterinarios { get; set; }

        public DateTime data { get; set; }

        public double peso { get; set; }

        public string sintomas { get; set; }

        public string diagnostico { get; set; }

        public double valor { get; set; }
    }
}
