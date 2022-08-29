using System;

namespace ClinicaVeterinaria.Models
{
    public class Animais
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string raca { get; set; }

        public DateTime dtNascimento { get; set; }

        public TipoAnimais tipoAnimais { get; set; }

        public Clientes cliente { get; set; }

    }
}
