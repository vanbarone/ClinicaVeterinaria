using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaVeterinaria.Models
{
    public abstract class Pessoa
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int id { get; set; }

        [Required(ErrorMessage = "Nome não informado")]
        public string nome { get; set; }

        [Required(ErrorMessage = "CPF não informado")]
        [RegularExpression("((\\d{11}))", ErrorMessage = "CPF inválido - Informe apenas números, sem formatação")]
        //[RegularExpression("((\\d{3}).(\\d{3}).(\\d{3})-(\\d{2}))", ErrorMessage = "CPF inválido - Utilize formato [999.999.999-99]")]
        [MaxLength(14)]
        public string cpf { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Email inválido")]
        public string email { get; set; }

        [RegularExpression("((\\d{5})-(\\d{4}))", ErrorMessage = "Telefone inválido - Utilize formato [99999-9999]")]
        //[RegularExpression("((\\d{2})\\s(\\d{5})-(\\d{4}))", ErrorMessage = "Telefone inválido - Utilize formato [99 99999-9999]")]
        [MaxLength(13)]
        public string celular { get; set; }
    }
}
