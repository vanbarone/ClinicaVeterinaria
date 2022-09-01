using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaVeterinaria.Models
{
    public abstract class Pessoa
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]     //não mostra esse campo no json na inserção e alteração
        public int id { get; set; }

        [Required(ErrorMessage = "Nome não informado")]
        public string nome { get; set; }

        [Required(ErrorMessage = "CPF não informado")]
        [RegularExpression("((\\d{11}))", ErrorMessage = "CPF inválido - Informe apenas números, sem formatação (Deve ter 11 dígitos)")]
        //[RegularExpression("((\\d{3}).(\\d{3}).(\\d{3})-(\\d{2}))", ErrorMessage = "CPF inválido - Utilize formato [999.999.999-99]")]
        [MaxLength(11)]
        public string cpf { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Email inválido")]
        public string email { get; set; }

        public string celular { get; set; }
    }
}
