using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models
{
    public class TipoAnimais
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Tipo não informado")]
        public string tipo { get; set; }
    }
}
