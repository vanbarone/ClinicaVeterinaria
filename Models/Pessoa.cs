using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models
{
    public class Pessoa
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nome não informado")]
        public string nome { get; set; }

        [Required(ErrorMessage = "CPF não informado")]
        public string cpf { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Email inválido")]
        public string email { get; set; }

        public string celular { get; set; }
    }
}
