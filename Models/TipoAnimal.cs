using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaVeterinaria.Models
{
    public class TipoAnimal
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int id { get; set; }

        [Required(ErrorMessage ="Tipo não informado")]
        public string tipo { get; set; }
    }
}
