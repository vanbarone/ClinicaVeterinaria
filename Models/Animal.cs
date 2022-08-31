using ClinicaVeterinaria.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaVeterinaria.Models
{
    public class Animal
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int id { get; set; }

        [Required(ErrorMessage = "Nome não informado")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Raça não informada")]
        public string raca { get; set; }

        public DateTime dtNascimento { get; set; }

        [Required(ErrorMessage = "Tipo do Animal não informado")]
        public int tipoAnimalId 
        {
            get { return tipoAnimal.id; }

            set {
                TipoAnimalRepository repo = new TipoAnimalRepository();

                tipoAnimal = repo.GetById(value);
            } 
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public TipoAnimal tipoAnimal { get; set; }

        [Required(ErrorMessage = "Cliente não informado")]
        public int clienteId
        {
            get { return cliente.id; }

            set
            {
                ClienteRepository repo = new ClienteRepository();

                cliente = repo.GetById(value);
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Cliente cliente { get; set; }

    }
}
