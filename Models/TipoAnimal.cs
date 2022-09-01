using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaVeterinaria.Models
{
    public class TipoAnimal
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]     //não mostra esse campo no json na inserção e alteração
        public int id { get; set; }
        
        [Required(ErrorMessage ="Tipo não informado")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string tipo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string imagem { get; set; }
    }
}
