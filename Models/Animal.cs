using System;

namespace ClinicaVeterinaria.Models
{
    public class Animal
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string raca { get; set; }

        public DateTime dtNascimento { get; set; }

        public TipoAnimal tipoAnimais { get; set; }

        public Cliente cliente { get; set; }

    }
}
